using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using BookReviews.Infrastructure.Identity;
using BookReviews.Application.Features.Auth.Commands.Login;

public class AccountMvcController : Controller
{
    private readonly SignInManager<ApplicationUser> _signInManager;

    public AccountMvcController(SignInManager<ApplicationUser> signInManager) => _signInManager = signInManager;

    [HttpGet("account/login")]
    public IActionResult Login() => View();

    [HttpPost("account/login")]
    public async Task<IActionResult> Login(LoginCommand command)
    {
        var result = await _signInManager.PasswordSignInAsync(command.Email, command.Password, false, false);
        if (result.Succeeded) return RedirectToAction("Index", "BooksMvc");
        
        ModelState.AddModelError("", "Invalid login attempt");
        return View();
    }

    [HttpGet("account/logout")]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "BooksMvc");
    }
}