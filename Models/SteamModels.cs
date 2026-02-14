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
