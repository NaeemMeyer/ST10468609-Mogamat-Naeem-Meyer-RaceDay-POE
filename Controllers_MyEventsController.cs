using Microsoft.AspNetCore.Mvc;
using RaceDayMVC.Models;
using RaceDayMVC.Services;

namespace RaceDayMVC.Controllers;

public class MyEventsController : Controller
{
    private readonly ApiService _apiService;

    public MyEventsController(ApiService apiService)
    {
        _apiService = apiService;
    }

    public async Task<IActionResult> Index()
    {
        int? participantId =
            HttpContext.Session.GetInt32("UserId");

        var enrolments =
            await _apiService.GetAsync<List<Enrolment>>(
                $"enrolments/participant/{participantId}");

        return View(enrolments);
    }

    public IActionResult EnterEvent(int id)
    {
        ViewBag.EventId = id;

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> EnterEvent(
        Enrolment enrolment)
    {
        enrolment.ParticipantId =
            HttpContext.Session.GetInt32("UserId")
            ?? 0;

        await _apiService.PostAsync<
            Enrolment,
            string>(
                "enrolments",
                enrolment);

        return RedirectToAction(nameof(Index));
    }
}
