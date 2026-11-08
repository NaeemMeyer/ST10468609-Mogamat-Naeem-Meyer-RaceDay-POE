using Microsoft.AspNetCore.Mvc;
using RaceDayMVC.Models;
using RaceDayMVC.Services;

namespace RaceDayMVC.Controllers;

public class MyResultsController : Controller
{
    private readonly ApiService _apiService;

    public MyResultsController(
        ApiService apiService)
    {
        _apiService = apiService;
    }

    public async Task<IActionResult> Index()
    {
        int? participantId =
            HttpContext.Session.GetInt32("UserId");

        var results =
            await _apiService
            .GetAsync<List<Result>>(
                $"results/{participantId}");

        return View(results);
    }
}
