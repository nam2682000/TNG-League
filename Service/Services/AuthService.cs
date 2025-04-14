using Application.Interfaces;
using System.Net.Http;
using System.Security.Claims;
using TngLeague.Domain;

namespace Application.Services;
public class AuthService : IAuthService
{
    private readonly AppDbContext _context;

    public AuthService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> LoginAsync(string username, string password)
    {
        return true;
    }
}
