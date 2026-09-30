namespace ExpenseTracker.API.DTOs;

/// <summary>
/// Lightweight status payload used in Phase 1 to prove the API,
/// CORS, and PostgreSQL wiring are working.
/// </summary>
public class HealthStatusDto
{
    public string Status { get; set; } = "ok";
    public string Application { get; set; } = "ExpenseTracker.API";
    public DateTime UtcNow { get; set; }
    public bool DatabaseConnected { get; set; }
    public string DatabaseProvider { get; set; } = string.Empty;
    public string? DatabaseMessage { get; set; }
}
