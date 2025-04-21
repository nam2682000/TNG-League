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
            Include(m => m.ThanhVienGiaiDaus)
            .ThenInclude(m=>m.ThanhVien)
            .FirstOrDefaultAsync(m => m.Id == idDoiDau);
        if (data is null)
            throw new Exception("Không tìm thấy đội đấu");
        DoiDauThanhVienModel result = new DoiDauThanhVienModel
        {
            DoiDauModel = _mapper.Map<DoiDauModel>(data),
            ThanhVienGiaiDaus =  data.ThanhVienGiaiDaus.Select(m=> new ThanhVienGiaiDauModel
            {
                Id = m.Id,
                HoTen = m.ThanhVien!.HoTen,
                TenThiDau = m.TenThiDau,
                SoAo = m.SoAo,
                LinkAvatar = m.ThanhVien.LinkAvatar,
                SoCCCD = m.ThanhVien.SoCCCD,
                Sdt = m.ThanhVien.Sdt.Value,
                DoiDauId = m.DoiDauId,
                VaiTroId = m.VaiTroId,
                ViTriId = m.ViTriId
            }).ToList(),
        };
        return result;
    }

    public async Task<List<DoiDauModel>> GetAllDoiDau(int idGiaiDau)
    {
        var data = await _context.DoiDaus
        .Include(m => m.ThanhVienGiaiDaus)
        .Include(m => m.TranDauThang)
        .Include(m => m.TranDauNha)
        .Include(m => m.TranDauKhach)
        .AsNoTracking()
        .Where(m => m.GiaiDauId == idGiaiDau)
        .Select(m => new DoiDauModel
        {
            Id = m.Id,
            TenDoiDau = m.TenDoiDau,
            LinkAvatar = m.LinkAvatar,
            SoThanhVien = m.ThanhVienGiaiDaus.Count,
            SoTranThang = m.TranDauThang.Count,
            SoTranThua = m.TranDauNha
                .Where(t => t.DoiDauThangId != null && t.DoiDauThangId != m.Id)
                .Concat(m.TranDauKhach
                    .Where(t => t.DoiDauThangId != null && t.DoiDauThangId != m.Id))
                .Count(),
            SoTranHoa = m.TranDauNha
                .Where(t => t.DoiDauThangId == null)
                .Concat(m.TranDauKhach
                    .Where(t => t.DoiDauThangId == null))
                .Count(),
            SoTranDaChoi = m.TranDauKhach.Count + m.TranDauNha.Count,
        })
        .ToListAsync();
        return data;
    }

    public async Task<bool> SuaDoiDau(int idDoi, DoiDauThanhVienModel model)
    {
        using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            #region  Cập nhật đội bóng
            var doiDau = await _context.DoiDaus.FindAsync(idDoi);
            if (doiDau is null) throw new Exception("Không tìm thấy đội đấu");

            _mapper.Map(model.DoiDauModel, doiDau);
            _context.DoiDaus.Update(doiDau);

            // 2. Thêm thành viên mới
            var modelAdds = model.ThanhVienGiaiDaus.Where(m => m.IsNew).ToList();
            var thanhVienAdds = _mapper.Map<List<ThanhVien>>(modelAdds);

            for (int i = 0; i < modelAdds.Count; i++)
            {
                if (modelAdds[i].FileAvatar is not null)
                {
                    thanhVienAdds[i].LinkAvatar = await _fileService.SaveFileAsync(modelAdds[i].FileAvatar!);
                }
            }

            _context.ThanhViens.AddRange(thanhVienAdds);
            await _context.SaveChangesAsync(); // để có được Id cho mỗi ThanhVien

            var thanhVienGiaiDauAdds = thanhVienAdds.Select((tv, i) =>
            {
                var thanhVienGiai = _mapper.Map<ThanhVienGiaiDau>(modelAdds[i]);
                thanhVienGiai.ThanhVienId = tv.Id;
                thanhVienGiai.DoiDauId = doiDau.Id;
                return thanhVienGiai;
            }).ToList();

            _context.ThanhVienGiaiDaus.AddRange(thanhVienGiaiDauAdds);
            #endregion

            #region Cập nhật thành viên cũ
            var modelUpdates = model.ThanhVienGiaiDaus.Where(m => m.IsChanged && !m.IsNew).ToList();
            var updateIds = modelUpdates.Select(m => m.Id).ToList();

            var thanhVienUpdates = await _context.ThanhVienGiaiDaus
                .Include(x => x.ThanhVien)
                .Where(x => updateIds.Contains(x.Id))
                .ToListAsync();

            var modelUpdateDict = modelUpdates?.ToDictionary(x => x.Id);

            foreach (var tvgd in thanhVienUpdates)
            {
                if (modelUpdateDict != null && modelUpdateDict.TryGetValue(tvgd.Id, out var updatedModel))
                {
                    tvgd.TenThiDau = updatedModel.TenThiDau;
                    tvgd.SoAo = updatedModel.SoAo;
                    tvgd.ViTriId = updatedModel.ViTriId;
                    tvgd.VaiTroId = updatedModel.VaiTroId;

                    tvgd.ThanhVien!.SoCCCD = updatedModel.SoCCCD;
                    tvgd.ThanhVien!.HoTen = updatedModel.HoTen;
                    tvgd.ThanhVien!.Sdt = updatedModel.Sdt;
                    if (updatedModel.FileAvatar is not null)
                    {
                        tvgd.ThanhVien!.LinkAvatar = await _fileService.SaveFileAsync(updatedModel.FileAvatar);
                    }
                }
            }
            #endregion

            // 4. Lưu & commit transaction
            await _context.SaveChangesAsync();
            await transaction.CommitAsync();
            return true;
        }
        catch (Exception)
        {
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

            int countThanhVien = thanhViens.Count;
            for (int i = 0; i < countThanhVien; i++)
            {
                if (model.ThanhVienGiaiDaus[i].FileAvatar != null)
                {
                    thanhViens[i].LinkAvatar = await _fileService.SaveFileAsync(model.ThanhVienGiaiDaus[i].FileAvatar!);
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
    public async Task<bool> XoaThanhVien(int id)
    {
       var thanhVien = await _context.ThanhVienGiaiDaus.FindAsync(id);
       if(thanhVien is null) throw new Exception("Không tìm thấy thành viên");
       _context.ThanhVienGiaiDaus.Remove(thanhVien);
       return await _context.SaveChangesAsync() > 0;
    }
    public Task<bool> XoaDoiDau(int idDoi)
    {
        throw new NotImplementedException();
    }
}
