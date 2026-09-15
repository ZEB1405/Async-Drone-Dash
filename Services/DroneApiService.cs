using System.Text.Json;
public class DroneApiService
{
    // Receive httpClient
    private readonly HttpClient _httpClient;

    public DroneApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<TodoModel> GetDataAsync(string url)
    {
        var response = await _httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();

        await using var stream = await response.Content.ReadAsStreamAsync();

        return await JsonSerializer.DeserializeAsync<TodoModel>(stream) ?? throw new Exception("Failed to deserialize API response.");
    }
}