using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.API.Data;

/// <summary>
/// Entity Framework Core database context.
/// Tables and relationships will be added in Phase 2.
/// Phase 1 only needs a context so the app can open a PostgreSQL connection.
/// </summary>
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
}
