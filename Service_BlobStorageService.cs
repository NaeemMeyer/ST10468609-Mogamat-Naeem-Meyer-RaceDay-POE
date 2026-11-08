using Azure.Storage.Blobs;

namespace RaceDayMVC.Services;

public class BlobStorageService
{
    private readonly BlobContainerClient _container;

    public BlobStorageService(IConfiguration config)
    {
        string connectionString =
            config["AzureStorage:ConnectionString"];

        string containerName =
            config["AzureStorage:ContainerName"];

        _container =
            new BlobContainerClient(
                connectionString,
                containerName);
    }

    public async Task<string> UploadFileAsync(
        IFormFile file)
    {
        var blob =
            _container.GetBlobClient(
                Guid.NewGuid() + Path.GetExtension(file.FileName));

        using var stream =
            file.OpenReadStream();

        await blob.UploadAsync(stream, true);

        return blob.Uri.ToString();
    }
}
