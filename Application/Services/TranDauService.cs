using Application.Interfaces;
using Application.Models;
using AutoMapper;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class TranDauService : ITranDauService
    {
        private readonly AppDbContext _context;

        public TranDauService(AppDbContext context)
        {
            _context = context;
        }


        public async Task<bool> CapNhatChiTietTranDau(int id, TranDauUpdate model)
        {
            var tranDau = await _context.TranDaus.FindAsync(id);
            if (tranDau is null)
            {
                throw new Exception("Không tìm thấy trận đấu");
            }
            tranDau.SoBanGhiDoiNha = model.SoBanGhiDoiNha;
            tranDau.SoBanGhiDoiKhach = model.SoBanGhiDoiKhach;
            tranDau.DiaDiem = model.DiaDiem;
            tranDau.NgayBatDau = model.NgayBatDau;
            tranDau.NgayKetThuc = model.NgayKetThuc;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<TranDauModel> ChiTietTranDau(int id)
        {
            var data = await _context.TranDaus.AsNoTracking().AsSplitQuery()
            .Include(m => m.DoiDauNha).ThenInclude(m => m.ThanhVienGiaiDaus).ThenInclude(m => m.ViTri)
            .Include(m => m.DoiDauKhach).ThenInclude(m => m.ThanhVienGiaiDaus).ThenInclude(m => m.ViTri)
            .Include(m => m.TranDauGhiBans).ThenInclude(m => m.ThanhVienGiaiDau)
            .Include(m => m.TranDauThePhats).ThenInclude(m => m.ThanhVienGiaiDau)
            .Select(i => new TranDauModel
            {
                Id = i.Id,
                NgayBatDau = i.NgayBatDau,
                NgayKetThuc = i.NgayKetThuc,
                DiaDiem = i.DiaDiem,
                ThanhVienGhiBans = i.TranDauGhiBans.Select(m => new ThanhVienSuKienModel
                {
                    Id = m.Id,
                    DoiDauId = m.ThanhVienGiaiDau != null ? m.ThanhVienGiaiDau.DoiDauId : null,
                    TenThiDau = m.ThanhVienGiaiDau != null ? m.ThanhVienGiaiDau.TenThiDau : string.Empty,
                    SoAo = m.ThanhVienGiaiDau != null ? m.ThanhVienGiaiDau.SoAo : 0,
                    IsGhiBan = true,
                    ThoiGian = m.ThoiGianGhiBan,
                }).ToList(),
                ThanhVienSuKiens = i.TranDauThePhats.Select(m => new ThanhVienSuKienModel
                {
                    Id = m.Id,
                    DoiDauId = m.ThanhVienGiaiDau != null ? m.ThanhVienGiaiDau.DoiDauId : null,
                    TenThiDau = m.ThanhVienGiaiDau != null ? m.ThanhVienGiaiDau.TenThiDau : string.Empty,
                    SoAo = m.ThanhVienGiaiDau != null ? m.ThanhVienGiaiDau.SoAo : 0,
                    IsTheDo = m.IsTheDo,
                    IsTheVang = m.IsTheVang,
                    ThoiGian = m.ThoiGianPhat,
                }).ToList(),
                ThanhVienRaTranDoiNhas = i.DoiDauNha.ThanhVienGiaiDaus.Select(m => new ThanhVienRaTranModel
                {
                    Id = m.Id,
                    TenThiDau = m.TenThiDau,
                    SoAo = m.SoAo,
                    TenViTri = m.ViTri.TenViTri
                }).ToList(),
                ThanhVienRaTranDoiKhachs = i.DoiDauKhach.ThanhVienGiaiDaus.Select(m => new ThanhVienRaTranModel
                {
                    Id = m.Id,
                    TenThiDau = m.TenThiDau,
                    SoAo = m.SoAo,
                    TenViTri = m.ViTri.TenViTri
                }).ToList(),
                DoiDauNhaId = i.DoiDauNha.Id,
                TenDoiNha = i.DoiDauNha.TenDoiDau,
                LinkAvatarDoiNha = i.DoiDauNha.LinkAnhDoi,
                SoBanGhiDoiNha = i.SoBanGhiDoiNha,
                DoiDauKhachId = i.DoiDauKhach.Id,
                TenDoiKhach = i.DoiDauKhach.TenDoiDau,
                LinkAvatarDoiKhach = i.DoiDauKhach.LinkAnhDoi,
                SoBanGhiDoiKhach = i.SoBanGhiDoiKhach,

            })
            .FirstOrDefaultAsync(m => m.Id == id);
            if (data is null)
                throw new Exception("Không tìm thấy trận đấu");
            return data;
        }

        public Task<List<LichThiDauModel>> GetLichThiDau(int? vongDauId, int? doiDauId)
        {
            var query = _context.TranDaus.AsNoTracking().AsQueryable();
            if(vongDauId !=null){
                query = query.Where(m=>m.GiaiDauVongDauChiTietId == vongDauId);
            }
            if(doiDauId !=null){
                query = query.Where(m=>m.DoiDauKhachId == doiDauId || m.DoiDauNhaId == doiDauId);
            }
            return query.Select(m=> new LichThiDauModel{
                TenDoiNha = m.DoiDauNha.TenDoiDau,
                DoiDauNhaId = m.DoiDauNhaId,
                SoBanGhiDoiNha = m.SoBanGhiDoiNha,
                LinkAvatarDoiNha = m.DoiDauNha.LinkAnhDoi,
                
                TenDoKhach = m.DoiDauKhach.TenDoiDau,
                DoiDauKhachId = m.DoiDauKhachId,
                SoBanGhiDoiKhach = m.SoBanGhiDoiKhach,
                LinkAvatarDoiKhach = m.DoiDauKhach.LinkAnhDoi,

                NgayBatDau = m.NgayBatDau,
                NgayKetThuc = m.NgayKetThuc,

            }).ToListAsync();
        }

        public Task<bool> SuaSuKien(int id, ThanhVienSuKienModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ThemSuKien(int idTranDau, ThanhVienSuKienModel model)
        {
            if(model.IsGhiBan){
                _context.TranDauGhiBans.Add(new Domain.Entities.TranDauGhiBan{
                    ThanhVienGiaiDauId = model.ThanhVienId,
                    ThoiGianGhiBan = model.ThoiGian,
                    TranDauId = idTranDau
                });
            }
            if(model.IsTheDo || model.IsTheVang){
                _context.TranDauThePhats.Add(new Domain.Entities.TranDauThePhat{
                    ThanhVienGiaiDauId = model.ThanhVienId,
                    ThoiGianPhat = model.ThoiGian,
                    TranDauId = idTranDau,
                    IsTheDo = model.IsTheDo,
                    IsTheVang = model.IsTheVang
                });
            }
            return await _context.SaveChangesAsync() > 0;
        }

        public Task<bool> ThemTranDau(List<TranDauAddModel> models)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> XoaSuKien(bool IsGhiBan,bool IsThePhat,int id)
        {
            if(IsGhiBan){
                var ghiBan = await _context.TranDauGhiBans.FindAsync(id);
                if(ghiBan is null)
                    throw new Exception("Không tìm thấy sự kiện");
                _context.TranDauGhiBans.Remove(ghiBan);
            }
            if(IsThePhat){
                var thePhat = await _context.TranDauThePhats.FindAsync(id);
                if(thePhat is null)
                    throw new Exception("Không tìm thấy sự kiện");
                _context.TranDauThePhats.Remove(thePhat);
            }
            return await _context.SaveChangesAsync() > 0;
        }

        public Task<bool> XoaTranDau(int id)
        {
            throw new NotImplementedException();
        }
    }
}
