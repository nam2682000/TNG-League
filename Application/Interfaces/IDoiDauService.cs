using Application.Models.DoiDau;

namespace Application.Interfaces
{
    public interface IDoiDauService
    {
        Task<bool> TaoDoiDau(List<DoiDauModel> doiDaus);
        Task<bool> SuaDoiDau(int idDoi, DoiDauModel doiDau);
        Task<bool> XoaDoiDau(int idDoi);
    }
}
