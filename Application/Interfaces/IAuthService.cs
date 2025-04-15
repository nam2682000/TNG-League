using Application.Models;

namespace Application.Interfaces;

public interface IAuthService
{
    public Task<bool> CheckLoginAsync(string username, string password);
}
