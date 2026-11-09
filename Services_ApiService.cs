using Newtonsoft.Json;
using RaceDayMVC.Models;
using System.Text;
using System.Text.Json;

namespace RaceDayMVC.Services;

public class ApiService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;

    public ApiService(
        HttpClient httpClient,
        IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
    }

    private string BaseUrl =>
        _configuration["ApiSettings:BaseUrl"];

    public async Task<T> GetAsync<T>(string endpoint)
    {
        var response =
            await _httpClient.GetAsync(BaseUrl + endpoint);

        response.EnsureSuccessStatusCode();

        var json =
            await response.Content.ReadAsStringAsync();

        return JsonConvert.DeserializeObject<T>(json);
    }

    public async Task<TResponse> PostAsync<TRequest, TResponse>(
        string endpoint,
        TRequest data)
    {
        var content =
            new StringContent(
                JsonSerializer.Serialize(data),
                Encoding.UTF8,
                "application/json");

        var response =
            await _httpClient.PostAsync(
                BaseUrl + endpoint,
                content);

        response.EnsureSuccessStatusCode();

        var json =
            await response.Content.ReadAsStringAsync();

        return JsonConvert.DeserializeObject<TResponse>(json);
    }

    // NEW METHOD FOR AZURE BLOB UPLOADS THROUGH API
    public async Task<string> UploadFileAsync(IFormFile file)
    {
        var formData = new MultipartFormDataContent();

      
