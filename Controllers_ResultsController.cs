using Microsoft.AspNetCore.Mvc;
using RaceDayMVC.Models;
using RaceDayMVC.Services;

namespace RaceDayMVC.Controllers;

public class ResultsController : Controller
{
    private readonly ApiService _apiService;

    public ResultsController(ApiService apiService)
    {
        _apiService = apiService;
    }

    public async Task<IActionResult> Index()
    {
        var results =
            await _apiService
            .GetAsync<List<Result>>("results");

        return View(results);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Result result)
    {
        await _apiService.PostAsync<Result, string>(
            "results",
            result);

        return RedirectToAction(nameof(Index));
    }
}
