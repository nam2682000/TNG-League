using Application.Models;

namespace Application.Interfaces;

public interface IAuthService
{
    public Task<bool> LoginAsync(string username, string password);
}
