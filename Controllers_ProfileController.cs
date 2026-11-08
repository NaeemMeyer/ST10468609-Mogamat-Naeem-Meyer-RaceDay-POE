using Microsoft.AspNetCore.Mvc;
using RaceDayMVC.Services;
using RaceDayMVC.ViewModels;

namespace RaceDayMVC.Controllers;

public class ProfileController : Controller
{
    private readonly ApiService _apiService;

    private readonly BlobStorageService _blobService;

    public ProfileController(
        ApiService apiService,
        BlobStorageService blobService)
    {
        _apiService = apiService;
        _blobService = blobService;
    }

    public async Task<IActionResult> Index()
    {
        int? id =
            HttpContext.Session.GetInt32("UserId");

        var profile =
            await _apiService
            .GetAsync<ProfileViewModel>(
                $"profile/{id}");

        return View(profile);
    }

    [HttpPost]
    public async Task<IActionResult> Update(
        ProfileViewModel model)
    {
        if(model.ProfilePicture != null)
        {
            model.ProfilePictureUrl =
                await _blobService
                .UploadFileAsync(
                    model.ProfilePicture);
        }

        await _apiService.PostAsync<
            ProfileViewModel,
            string>(
            "profile/update",
            model);

        return RedirectToAction(nameof(Index));
    }
}
