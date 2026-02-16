using Microsoft.Extensions.Options;
using System.Text;
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
        var url = $"https://api.steampowered.com/ISteamUser/GetPlayerSummaries/v0002/?key={_apiKey}&steamids={steamId}";

        // The API returns a list of players, but since we're querying for a single Steam ID, we will take the first one.
        // GetFromJSONAsync will automatically deserialize the JSON response into our PlayerSummaryResponse model.
        var response = await _httpClient.GetFromJsonAsync<PlayerSummaryResponse>(url);

        return response?.Response.Players.FirstOrDefault();
    }

    public async Task<List<Friend>?> GetFriendListAsync(string steamId)
    {
        var url = $"https://api.steampowered.com/ISteamUser/GetFriendList/v0001/?key={_apiKey}&steamid={steamId}&relationship=friend";

        // Deserialize the JSON response into a list of Friend objects. The API returns a list of friends, but since we're querying for a single Steam ID, we will take the first one.
        //var response = await _httpClient.GetFromJsonAsync<List<Friend>>(url);
        var response = await _httpClient.GetFromJsonAsync<FriendListResponse>(url);

        // View the raw JSON response in the console for debugging purposes.
        //var json = await _httpClient.GetFromJsonAsync<JsonDocument>(url);
        //Console.WriteLine(json.RootElement.ToString());

        return response?.Response.Friends;
    }

    // Used to get friend summaries in batches, since the GetPlayerSummaries API endpoint has a limit of 100 Steam IDs per request.
    public async Task<List<PlayerSummary>?> GetFriendSummariesAsync(List<string> steamIds)
    {
        // Join all the Steam IDs into a single comma-separated string, which is the format required by the GetPlayerSummaries API endpoint.
        string ids = string.Join(",", steamIds);

        var url = $"https://api.steampowered.com/ISteamUser/GetPlayerSummaries/v0002/?key={_apiKey}&steamids={ids}";
        // The API returns a list of players, but since we're querying for a single Steam ID, we will take the first one.
        // GetFromJSONAsync will automatically deserialize the JSON response into our PlayerSummaryResponse model.
        var response = await _httpClient.GetFromJsonAsync<PlayerSummaryResponse>(url);

        // Return the list of friend summaries, ordered alphabetically by their PersonaName. If the response is null, return null.
        return response?.Response.Players.OrderBy(item => item.PersonaName).ToList();
    }

    public async Task<List<OwnedGame>?> GetOwnedGamesAsync(string steamId)
    {
        var url = $"https://api.steampowered.com/IPlayerService/GetOwnedGames/v0001/?key={_apiKey}&steamid={steamId}&include_appinfo=true&include_played_free_games=true";

        // The API returns a list of owned games, but since we're querying for a single Steam ID, we will take the first one.
        // GetFromJSONAsync will automatically deserialize the JSON response into our OwnedGamesResponse model.
        var response = await _httpClient.GetFromJsonAsync<OwnedGamesResponse>(url);
        return response?.Response.Games.OrderByDescending(item => item.TotalPlaytime).ToList();
    }
}
