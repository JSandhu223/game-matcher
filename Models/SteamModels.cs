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
