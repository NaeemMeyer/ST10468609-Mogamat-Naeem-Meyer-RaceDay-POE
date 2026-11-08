using Microsoft.AspNetCore.Mvc;
using RaceDayMVC.Models;
using RaceDayMVC.Services;

namespace RaceDayMVC.Controllers;

public class EnrolmentsController : Controller
{
    private readonly ApiService _apiService;

    public EnrolmentsController(
        ApiService apiService)
    {
        _apiService = apiService;
    }

    public async Task<IActionResult> Index()
    {
        var enrolments =
            await _apiService
            .GetAsync<List<Enrolment>>(
                "enrolments");

        return View(enrolments);
    }
}
