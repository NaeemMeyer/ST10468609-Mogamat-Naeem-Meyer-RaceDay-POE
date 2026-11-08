using Microsoft.AspNetCore.Mvc;
using RaceDayMVC.Models;
using RaceDayMVC.Services;

namespace RaceDayMVC.Controllers;

public class CategoriesController : Controller
{
    private readonly ApiService _apiService;

    public CategoriesController(
        ApiService apiService)
    {
        _apiService = apiService;
    }

    public async Task<IActionResult> Index()
    {
        var categories =
            await _apiService
            .GetAsync<List<Category>>(
                "categories");

        return View(categories);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        Category category)
    {
        await _apiService.PostAsync<Category, string>(
            "categories",
            category);

        return RedirectToAction(nameof(Index));
    }
}
