using ExpenseTracker.API.Data;
using ExpenseTracker.API.DTOs;
using ExpenseTracker.API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.API.Services;

public class HealthService : IHealthService
{
    private readonly AppDbContext _dbContext;
    private readonly ILogger<HealthService> _logger;

    public HealthService(AppDbContext dbContext, ILogger<HealthService> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public async Task<HealthStatusDto> GetStatusAsync(CancellationToken cancellationToken = default)
    {
        var status = new HealthStatusDto
        {
            UtcNow = DateTime.UtcNow,
            DatabaseProvider = _dbContext.Database.ProviderName ?? "unknown"
        };

        try
        {
            status.DatabaseConnected = await _dbContext.Database.CanConnectAsync(cancellationToken);
            status.Status = status.DatabaseConnected ? "ok" : "degraded";
            status.DatabaseMessage = status.DatabaseConnected
                ? "Successfully connected to PostgreSQL."
                : "The API is running, but it could not connect to PostgreSQL.";
        }
        catch (Exception exception)
        {
            // Keep details in logs. Return a safe message to the client.
            _logger.LogWarning(exception, "PostgreSQL health check failed.");
            status.DatabaseConnected = false;
            status.Status = "degraded";
            status.DatabaseMessage =
                "The API is running, but it could not connect to PostgreSQL. Check the connection string and that the database is running.";
        }

        return status;
    }
}
