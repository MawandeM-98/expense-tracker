using ExpenseTracker.API.DTOs;
using ExpenseTracker.API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class HealthController : ControllerBase
{
    private readonly IHealthService _healthService;

    public HealthController(IHealthService healthService)
    {
        _healthService = healthService;
    }

    /// <summary>
    /// Returns API process status and whether PostgreSQL is reachable.
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(HealthStatusDto), StatusCodes.Status200OK)]
    public async Task<ActionResult<HealthStatusDto>> Get(CancellationToken cancellationToken)
    {
        var status = await _healthService.GetStatusAsync(cancellationToken);
        return Ok(status);
    }
}
