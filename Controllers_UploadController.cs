using Microsoft.AspNetCore.Mvc;
using RaceDayAPI.Models;
using RaceDayAPI.Services;

namespace RaceDayAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UploadController : ControllerBase
{
    private readonly AzureBlobService _blobService;

    public UploadController(
        AzureBlobService blobService)
    {
        _blobService = blobService;
    }

    [HttpPost]
    public async Task<IActionResult> Upload(
        IFormFile file)
    {
        if (file == null)
            return BadRequest("No file supplied.");

        string url =
            await _blobService
                .UploadAsync(file);

        return Ok(new BlobResponse
        {
            Url = url
        });
    }
}
