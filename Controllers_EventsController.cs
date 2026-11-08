using Microsoft.AspNetCore.Mvc;
using RaceDayMVC.Services;
using RaceDayMVC.ViewModels;

namespace RaceDayMVC.Controllers;

public class EventsController : Controller
{
    private readonly ApiService _apiService;

    private readonly BlobStorageService _blobService;

    public EventsController(
        ApiService apiService,
        BlobStorageService blobService)
    {
        _apiService = apiService;
        _blobService = blobService;
    }

    public async Task<IActionResult> Index()
    {
        var events =
            await _apiService
            .GetAsync<List<EventViewModel>>("events");

        return View(events);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        EventViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        if (model.BannerImage != null)
        {
            model.BannerUrl =
                await _blobService
                .UploadFileAsync(model.BannerImage);
        }

        await _apiService.PostAsync<EventViewModel, string>(
            "events",
            model);

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id)
    {
        var ev =
            await _apiService
            .GetAsync<EventViewModel>(
                $"events/{id}");

        return View(ev);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(
        EventViewModel model)
    {
        await _apiService.PostAsync<EventViewModel, string>(
            $"events/update/{model.EventId}",
            model);

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id)
    {
        await _apiService.PostAsync<int, string>(
            $"events/delete/{id}",
            id);

        return RedirectToAction(nameof(Index));
    }
}

public async Task<IActionResult> Details(int id)
{
    var eventDetails =
        await _apiService.GetAsync<EventDetailsViewModel>(
            $"events/{id}");

    return View(eventDetails);
}
