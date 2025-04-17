using Application.Interfaces;
using Application.Models;
using AutoMapper;
using Domain;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Services;

public class DoiDauService : IDoiDauService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;
    private readonly IFileService _fileService;
    public DoiDauService(AppDbContext context, IMapper mapper, IFileService fileService)
    {
        _context = context;
        _mapper = mapper;
        _fileService = fileService;
    }

    public async Task<DoiDauThanhVienModel> ChiTietDoiDau(int idDoiDau)
    {
        var data = await _context.DoiDaus.AsNoTracking().
            Include(m => m.ThanhVienGiaiDaus).FirstOrDefaultAsync(m => m.Id == idDoiDau);
        if (data is null)
            throw new Exception("Không tìm thấy đội đấu");
        DoiDauThanhVienModel result = new DoiDauThanhVienModel
        {
            DoiDauModel = _mapper.Map<DoiDauModel>(data),
            ThanhVienGiaiDaus = _mapper.Map<List<ThanhVienGiaiDauModel>>(data.ThanhVienGiaiDaus),
        };
        return result;
    }

    public async Task<List<DoiDauModel>> GetAllDoiDau(int idGiaiDau)
    {
        var data = await _context.DoiDaus.AsNoTracking().Where(m=>m.GiaiDauId == idGiaiDau).ToListAsync();
        var result = _mapper.Map<List<DoiDauModel>>(data);
        return result;
    }

    public async Task<bool> SuaDoiDau(int idDoi, DoiDauThanhVienModel model)
    {
        using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            var doiDau = await _context.DoiDaus.FindAsync(idDoi);
            if (doiDau is null)
            {
                throw new Exception("Không tìm thấy đội đấu");
            }
            _mapper.Map(model.DoiDauModel, doiDau);
            _context.DoiDaus.Update(doiDau);

            #region xử lý với các thành viên mới được thêm
            var modelAdd = model.ThanhVienGiaiDaus.Where(m => m.IsNew).ToList();
            var thanhVienAdds = _mapper.Map<List<ThanhVien>>(modelAdd);
            int countThanhVien = thanhVienAdds.Count;
            for (int i = 0; i < countThanhVien; i++)
            {
                if (modelAdd[i]?.FileAvatar != null)
                {
                    thanhVienAdds[i].LinkAvatar = await _fileService.SaveFileAsync(modelAdd[i]?.FileAvatar!);
                }
            }

            _context.ThanhViens.AddRange(thanhVienAdds);

            var thanhVienGiaiDauAdds = thanhVienAdds.Select((tv, i) =>
            {
                var thanhVienGiai = _mapper.Map<ThanhVienGiaiDau>(modelAdd[i]);
                thanhVienGiai.ThanhVienId = tv.Id;
                thanhVienGiai.DoiDauId = doiDau.Id;
                return thanhVienGiai;
            }).ToList();
            _context.ThanhVienGiaiDaus.AddRange(thanhVienGiaiDauAdds);
            #endregion

            #region xử lý các thành viên bị sửa
            var modelUpdate = model.ThanhVienGiaiDaus.Where(m => m.IsChanged).ToList();
            var ids = modelUpdate.Select(m => m.Id).ToArray();

            var thanhVienUpdate = await _context.ThanhVienGiaiDaus
                .Include(m => m.ThanhVien)
                .Where(m => ids.Contains(m.Id)).ToListAsync();

            int countThanhVienUpdate = thanhVienUpdate.Count;
            var modelUpdateDict = modelUpdate.ToDictionary(x => x.Id);
            foreach (var tv in thanhVienUpdate)
            {
                if (modelUpdateDict.TryGetValue(tv.Id, out var update))
                {
                    _mapper.Map(update, tv);
                    _mapper.Map(update, tv.ThanhVien);
                    if (update.FileAvatar != null)
                    {
                        tv.ThanhVien!.LinkAvatar = await _fileService.SaveFileAsync(update.FileAvatar);
                    }
                }
            }
            #endregion

            await _context.SaveChangesAsync();
            await transaction.CommitAsync();
            return true;
        }
        catch (Exception ex)
        {
            // Rollback nếu có lỗi
            await transaction.RollbackAsync();
            return false;
        }
    }

    public async Task<bool> TaoDoiDau(int giaiDauId, DoiDauThanhVienModel model)
    {
        using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            DoiDau doiDau = _mapper.Map<DoiDau>(model.DoiDauModel);
            doiDau.GiaiDauId = giaiDauId;
            _context.DoiDaus.Add(doiDau);
            await _context.SaveChangesAsync();

            var thanhViens = _mapper.Map<List<ThanhVien>>(model.ThanhVienGiaiDaus);

            var thanhVienModelDict = model.ThanhVienGiaiDaus.ToDictionary(m => m.Id);
            foreach (var tv in thanhViens)
            {
                if(thanhVienModelDict.TryGetValue(tv.Id, out var modelAdd))
                {
                    if(modelAdd.FileAvatar != null)
                    {
                        tv.LinkAvatar = await _fileService.SaveFileAsync(modelAdd.FileAvatar!);
                    }
                }
            }
            _context.ThanhViens.AddRange(thanhViens);
            await _context.SaveChangesAsync();

            var thanhVienGiaiDaus = thanhViens.Select((tv, i) => {
                var thanhVienGiai = _mapper.Map<ThanhVienGiaiDau>(model.ThanhVienGiaiDaus[i]);
                thanhVienGiai.ThanhVienId = tv.Id;
                thanhVienGiai.DoiDauId = doiDau.Id;
                return thanhVienGiai;
            }).ToList();

            _context.ThanhVienGiaiDaus.AddRange(thanhVienGiaiDaus);
            await _context.SaveChangesAsync();
            await transaction.CommitAsync();
            return true;
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            return false;
        }
    }

    public Task<bool> XoaDoiDau(int idDoi)
    {
        throw new NotImplementedException();
    }
}
