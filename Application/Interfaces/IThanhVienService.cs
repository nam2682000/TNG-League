using Application.Models;
using Application.Models.ThanhVien;

namespace Application.Interfaces
{
    public interface IThanhVienService
    {
        bool TaoThanhVien(List<ThanhVienModel> thanhViens);
        bool SuaThanhVien(int id, ThanhVienModel thanhVien);
        bool XoaThanhVien(int id);
    }
}
