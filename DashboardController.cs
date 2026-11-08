using Microsoft.AspNetCore.Mvc;
using RaceDayMVC.Services;
using RaceDayMVC.ViewModels;

namespace RaceDayMVC.Controllers;

public class DashboardController : Controller
{
    private readonly ApiService _apiService;

    public DashboardController(ApiService apiService)
    {
        _apiService = apiService;
    }

    public async Task<IActionResult> Dashboard()
    {
        if (HttpContext.Session.GetString("Role") != "Organiser")
        {
            return RedirectToAction("Login", "Account");
        }

        var events =
            await _apiService
            .GetAsync<List<EventViewModel>>("events");

        DashboardViewModel vm =
            new DashboardViewModel
            {
                TotalEvents = events.Count,
                UpcomingEvents =
                    events.Count(e => e.Date > DateTime.Now),

                Events = events
            };

        return View(vm);
    }
}
