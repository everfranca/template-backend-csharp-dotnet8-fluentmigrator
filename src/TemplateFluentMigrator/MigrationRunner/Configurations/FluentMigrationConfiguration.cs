using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;
using FluentMigrator.Postgres;
using Migrations;

namespace MigrationRunner.Configurations;

public static class FluentMigrationConfiguration
{
    public static void AddFluentMigrator(this IServiceCollection services, string connectionString)
    {
        services.AddFluentMigratorCore()
            .ConfigureRunner(rb => rb
                .AddPostgres11_0()
                .WithGlobalConnectionString(connectionString)
                .ScanIn(typeof(M202517010910).Assembly).For.Migrations())
            .AddLogging(lb => lb.AddFluentMigratorConsole());
    }
}