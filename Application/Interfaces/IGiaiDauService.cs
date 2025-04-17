using Application.Models;

namespace Application.Interfaces
{
    public interface IGiaiDauService
    {
        Task<List<GiaiDauModel>> GetAllGiaiDau();
        Task<GiaiDauModel> GetGiaiDau(int id);
        Task<bool> TaoGiaiDau(GiaiDauModel giaiDau);
        Task<bool> SuaGiaiDau(int id, GiaiDauModel giaiDau);
        Task<bool> XoaGiaiDau(int id);
    }
}
