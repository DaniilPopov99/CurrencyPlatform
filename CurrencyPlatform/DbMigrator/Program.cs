using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PSQL.Infrastructure.DbContexts;
using PSQL.Infrastructure.Extensions;
using Serilog;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddSerilog((services, configuration) =>
{
    configuration
        .ReadFrom.Configuration(builder.Configuration)
        .ReadFrom.Services(services)
        .Enrich.FromLogContext();
});

builder.Services.AddPSQLInfrastructure(builder.Configuration);

var host = builder.Build();

try
{
    Log.Information("Starting DbMigrator...");

    using var scope = host.Services.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<CurrencyDbContext>();

    Log.Information("Applying migrations...");

    await db.Database.MigrateAsync();

    Log.Information("Migrations applied successfully");

    Log.Information("DbMigrator finished");
    return 0;
}
catch (Exception ex)
{
    Log.Fatal(ex, "Migration failed");
    return 1;
}
finally
{
    await Log.CloseAndFlushAsync();
}