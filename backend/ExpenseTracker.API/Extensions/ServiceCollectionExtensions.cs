using ExpenseTracker.API.Configuration;
using ExpenseTracker.API.Data;
using ExpenseTracker.API.Interfaces;
using ExpenseTracker.API.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;

namespace ExpenseTracker.API.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddExpenseTrackerServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddControllers();
        services.AddCorsPolicy(configuration);
        services.AddSwaggerDocumentation();
        services.AddPostgreSql(configuration);

        services.AddScoped<IHealthService, HealthService>();

        return services;
    }

    private static IServiceCollection AddCorsPolicy(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var corsSettings = configuration
            .GetSection(CorsSettings.SectionName)
            .Get<CorsSettings>() ?? new CorsSettings();

        services.AddCors(options =>
        {
            options.AddPolicy("Frontend", policy =>
            {
                policy
                    .WithOrigins(corsSettings.AllowedOrigins)
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
        });

        return services;
    }

    private static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Expense Tracker API",
                Version = "v1",
                Description =
                    "Personal finance Web API. Phase 1 exposes a health endpoint so you can verify CORS, Swagger, and PostgreSQL."
            });
        });

        return services;
    }

    private static IServiceCollection AddPostgreSql(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        if (string.IsNullOrWhiteSpace(connectionString))
        {
            throw new InvalidOperationException(
                "Connection string 'DefaultConnection' is missing. Set it in appsettings.Development.json, user secrets, or an environment variable.");
        }

        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(connectionString));

        return services;
    }
}
