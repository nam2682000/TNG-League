using Application.Interfaces;
using Application.Models.DoiDau;

namespace Application.Services;

public class DoiDauService : IDoiDauService
{
    public Task<bool> SuaDoiDau(int idDoi, DoiDauModel doiDau)
    {
        throw new NotImplementedException();
    }

    public Task<bool> TaoDoiDau(List<DoiDauModel> doiDaus)
    {
        throw new NotImplementedException();
    }

    public Task<bool> XoaDoiDau(int idDoi)
    {
        throw new NotImplementedException();
    }
}
