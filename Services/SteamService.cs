using Microsoft.Extensions.Options;

public class SteamService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;

    public SteamService(HttpClient httpClient, IConfiguration config)
    {
        _httpClient = httpClient;
        _apiKey = config["Steam:ServiceApiKey"]!;
    }

    public async Task<PlayerSummary?> GetPlayerSummaryAsync(string steamId)
    {
        var url = $"https://api.steampowered.com/ISteamUser/GetPlayerSummaries/v2/" +
                  $"?key={_apiKey}&steamids={steamId}";

        var response = await _httpClient.GetFromJsonAsync<PlayerSummaryResponse>(url);

        return response?.Response.Players.FirstOrDefault();
    }
}
