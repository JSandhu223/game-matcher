using System.Text.Json.Serialization;

public class PlayerSummaryResponse
{
    [JsonPropertyName("response")]
    public PlayerContainer Response { get; set; } = new();
}

public class PlayerContainer
{
    [JsonPropertyName("players")]
    public List<PlayerSummary> Players { get; set; } = new();
}

public class PlayerSummary
{
    [JsonPropertyName("steamid")]
    public string SteamId { get; set; } = "";

    [JsonPropertyName("personaname")]
    public string PersonaName { get; set; } = "";

    [JsonPropertyName("profileurl")]
    public string ProfileUrl { get; set; } = "";

    [JsonPropertyName("avatarmedium")]
    public string AvatarMedium { get; set; } = "";

    [JsonPropertyName("avatarfull")]
    public string AvatarFull { get; set; } = "";

    [JsonPropertyName("personastate")]
    public int PersonaState { get; set; }
}

public class FriendListResponse
{
    [JsonPropertyName("friendslist")]
    public FriendListContainer Response { get; set; } = new();
}

public class FriendListContainer
{
    [JsonPropertyName("friends")]
    public List<Friend> Friends { get; set; } = new();
}

public class Friend
{
    [JsonPropertyName("steamid")]
    public string SteamId { get; set; } = "";

    [JsonPropertyName("relationship")]
    public string Relationship { get; set; } = "";

    [JsonPropertyName("friend_since")]
    public long FriendSince { get; set; }
}

public class OwnedGamesResponse
{
    [JsonPropertyName("response")]
    public OwnedGamesContainer Response { get; set; } = new();
}

public class OwnedGamesContainer
{
    [JsonPropertyName("games")]
    public List<OwnedGame> Games { get; set; } = new();
}

public class OwnedGame
{
    [JsonPropertyName("appid")]
    public int AppId { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; } = "";

    [JsonPropertyName("playtime_forever")]
    public double TotalPlaytime { get; set; }

    // The API returns the image hash, which can be used to construct the URL for the game's icon. The URL format is: http://media.steampowered.com/steamcommunity/public/images/apps/{appid}/{img_icon_url}.jpg
    [JsonPropertyName("img_icon_url")]
    public string ImageHash { get; set; } = "";
}