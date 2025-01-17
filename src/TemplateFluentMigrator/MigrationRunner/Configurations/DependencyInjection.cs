using Microsoft.Extensions.DependencyInjection;
using MigrationRunner.Operations.MigrationDown;
using MigrationRunner.Operations.MigrationUp;

namespace MigrationRunner.Configurations;

public static class DependencyInjection
{
    public static void AddMigrationRunner(this IServiceCollection services)
    {
        services.AddTransient<IMigrationDown, MigrationDown>();
        services.AddTransient<IMigrationUp, MigrationUp>();
    }
}