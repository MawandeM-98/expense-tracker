namespace ExpenseTracker.API.Configuration;

/// <summary>
/// CORS settings bound from appsettings.json.
/// Origins are listed in configuration so they are not hardcoded in Program.cs.
/// </summary>
public class CorsSettings
{
    public const string SectionName = "Cors";

    public string[] AllowedOrigins { get; set; } = [];
}
