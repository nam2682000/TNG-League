using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Application.Services;
public class AuthService : IAuthService
{

    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly UserManager<ApplicationUser> _userManager;

    public AuthService(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
    {
        _signInManager = signInManager;
        _userManager = userManager;
    }

    public async Task<bool> CheckLoginAsync(string username, string password)
    {
        var user = await _userManager.FindByNameAsync(username);

        if (user == null)
            return false;

        var result = await _signInManager.CheckPasswordSignInAsync(user, password, lockoutOnFailure: false);
        return result.Succeeded;
    }
}
