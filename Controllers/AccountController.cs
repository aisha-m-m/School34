using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace School34.Controllers;

public class AccountController : Controller
{
    public IActionResult Login(string? returnUrl = null)
    {
        ViewBag.ReturnUrl = returnUrl;
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(string code, string password, string? returnUrl = null)
    {
        var conf = HttpContext.RequestServices.GetRequiredService<IConfiguration>();
        var expectedCode = conf["Admin:Code"] ?? "admin";
        var expectedPass = conf["Admin:Password"] ?? "1234";
        if (code == expectedCode && password == expectedPass)
        {
            var claims = new List<Claim> { new Claim(ClaimTypes.Name, "Admin"), new Claim(ClaimTypes.Role, "Admin") };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
            return Redirect(returnUrl ?? Url.Action("Index", "Home")!);
        }
        ViewBag.Error = "Неверный код или пароль";
        return View();
    }

    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Index", "Home");
    }

    public IActionResult Denied() => Content("Доступ запрещен");
}

