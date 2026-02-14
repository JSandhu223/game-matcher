using System.Text.Json.Serialization;

public class PlayerSummaryResponse
{
    public PlayerContainer Response { get; set; } = new();
}

public class PlayerContainer
{
    public List<PlayerSummary> Players { get; set; } = new();
}

public class PlayerSummary
{
    public string SteamId { get; set; } = "";
    public string PersonaName { get; set; } = "";
    public string AvatarFull { get; set; } = "";
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
