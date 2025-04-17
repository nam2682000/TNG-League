using Application.Models.GiaiDau;

namespace Application.Interfaces
{
    public interface IGiaiDauService
    {
        Task<bool> TaoGiaiDau(GiaiDauModel giaiDau);
        Task<bool> SuaGiaiDau(int id, GiaiDauModel giaiDau);
        Task<bool> XoaGiaiDau(int id);
    }
}
