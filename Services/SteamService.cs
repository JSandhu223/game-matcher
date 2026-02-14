using Microsoft.Extensions.Options;
using System.Text.Json;

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
        var url = $"https://api.steampowered.com/ISteamUser/GetPlayerSummaries/v0002/" +
                  $"?key={_apiKey}&steamids={steamId}";

        // The API returns a list of players, but since we're querying for a single Steam ID, we will take the first one.
        // GetFromJSONAsync will automatically deserialize the JSON response into our PlayerSummaryResponse model.
        var response = await _httpClient.GetFromJsonAsync<PlayerSummaryResponse>(url);
        var responseString = await _httpClient.GetStringAsync(url);

        return response?.Response.Players.FirstOrDefault();
    }

    public async Task<Friend?> GetFriendListAsync(string steamId)
    {
        var url = $"https://api.steampowered.com/ISteamUser/GetFriendList/v0001/?key={_apiKey}&steamid={steamId}&relationship=friend";

        // Deserialize the JSON response into a list of Friend objects. The API returns a list of friends, but since we're querying for a single Steam ID, we will take the first one.
        //var response = await _httpClient.GetFromJsonAsync<List<Friend>>(url);
        var response = await _httpClient.GetFromJsonAsync<FriendListResponse>(url);
        var responseString = await _httpClient.GetStringAsync(url);

        // View the raw JSON response in the console for debugging purposes.
        //var json = await _httpClient.GetFromJsonAsync<JsonDocument>(url);
        //Console.WriteLine(json.RootElement.ToString());

        return response?.Response.Friends.FirstOrDefault();
    }
}
