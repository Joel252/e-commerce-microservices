using Microservices.Services.CouponAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace Microservices.Services.CouponAPI.Extensions;

/// <summary>
/// Extension method for applying database migrations.
/// </summary>
public static class DatabaseMigrationExtension
{
    /// <summary>
    /// Applies database migrations.
    /// </summary>
    /// <param name="app">The web application instance</param>
    public static void ApplyMigration(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        // Get the database context from the service provider
        var db = scope.ServiceProvider.GetRequiredService<CouponDbContext>();
        // Get the logger from the service provider
        var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();

        logger.LogInformation("Checking for pending migrations...");

        // Check if there are any pending migrations
        var pendingMigrations = db.Database.GetPendingMigrations().ToList();
        if (pendingMigrations.Count == 0)
        {
            logger.LogInformation("No pending migrations found.");
            return;
        }

        try
        {
            logger.LogInformation("Found {count} pending migrations. Applying...", pendingMigrations.Count);
            db.Database.Migrate(); // Apply migrations
            logger.LogInformation("Migrations applied successfully.");
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while applying migrations.");
        }
    }
}