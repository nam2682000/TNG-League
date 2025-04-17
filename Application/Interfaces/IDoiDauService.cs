using Application.Models;

namespace Application.Interfaces
{
    public interface IDoiDauService
    {
        Task<List<DoiDauModel>> GetAllDoiDau(int idGiaiDau);
        Task<DoiDauThanhVienModel> ChiTietDoiDau(int idDoiDau);
        Task<bool> TaoDoiDau(int giaiDauId, DoiDauThanhVienModel model);
        Task<bool> SuaDoiDau(int idDoi, DoiDauThanhVienModel model);
        Task<bool> XoaDoiDau(int idDoi);
    }
}
