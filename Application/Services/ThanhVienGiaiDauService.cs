using Application.Interfaces;
using Application.Models;
using Domain;

namespace Application.Services
{
    public class ThanhVienGiaiDauService : IThanhVienGiaiDauService
    {
        private readonly AppDbContext _context;

        public ThanhVienGiaiDauService(AppDbContext context)
        {
            _context = context;
        }

        public bool SuaThanhVien(int id, ThanhVienGiaiDauModel thanhVien)
        {
            throw new NotImplementedException();
        }

        public bool TaoThanhVien(List<ThanhVienGiaiDauModel> thanhViens)
        {
            throw new NotImplementedException();
        }

        public bool XoaThanhVien(int id)
        {
            throw new NotImplementedException();
        }
    }
}
