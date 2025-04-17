using Application.Models;

namespace Application.Interfaces
{
    public interface IThanhVienGiaiDauService
    {
        bool TaoThanhVien(List<ThanhVienGiaiDauModel> thanhViens);
        bool SuaThanhVien(int id, ThanhVienGiaiDauModel thanhVien);
        bool XoaThanhVien(int id);
    }
}
