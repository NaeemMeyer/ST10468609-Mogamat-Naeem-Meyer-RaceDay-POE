using Microsoft.AspNetCore.Mvc;
using RaceDayMVC.Models;
using RaceDayMVC.Services;
using RaceDayMVC.ViewModels;

namespace RaceDayMVC.Controllers;

public class AccountController : Controller
{
    private readonly ApiService _apiService;

    public AccountController(ApiService apiService)
    {
        _apiService = apiService;
    }

    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        try
        {
            var request = new LoginRequest
            {
                Email = model.Email,
                Password = model.Password
            };

            var response =
                await _apiService.PostAsync<LoginRequest,
                    LoginResponse>(
                        "auth/login",
                        request);

            HttpContext.Session.SetInt32(
                "UserId",
                response.UserId);

            HttpContext.Session.SetString(
                "Role",
                response.Role);

            HttpContext.Session.SetString(
                "Name",
                response.Name);

            if (response.Role == "Organiser")
                return RedirectToAction(
                    "Dashboard",
                    "Dashboard");

            return RedirectToAction(
                "Index",
                "Participant");
        }
        catch
        {
            ViewBag.Error =
                "Invalid email or password.";

            return View(model);
        }
    }

    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(
        RegisterViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        try
        {
            var request =
                new RegisterRequest
                {
                    Name = model.Name,
                    Surname = model.Surname,
                    Email = model.Email,
                    Password = model.Password,
                    Role = model.Role
                };

            await _apiService.PostAsync<
                RegisterRequest,
                string>(
                    "auth/register",
                    request);

            TempData["Success"] =
                "Registration successful.";

            return RedirectToAction("Login");
        }
        catch
        {
            ViewBag.Error =
                "Registration failed.";

            return View(model);
        }
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Clear();

        return RedirectToAction(
            "Login",
            "Account");
    }
}
