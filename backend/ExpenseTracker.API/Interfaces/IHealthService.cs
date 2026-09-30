using ExpenseTracker.API.DTOs;

namespace ExpenseTracker.API.Interfaces;

public interface IHealthService
{
    Task<HealthStatusDto> GetStatusAsync(CancellationToken cancellationToken = default);
}
