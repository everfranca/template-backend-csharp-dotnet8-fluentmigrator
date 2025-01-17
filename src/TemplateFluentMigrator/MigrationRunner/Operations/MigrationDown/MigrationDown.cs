using FluentMigrator.Runner;

namespace MigrationRunner.Operations.MigrationDown;

public class MigrationDown : IMigrationDown
{
    private readonly IMigrationRunner _migrationRunner;
    public MigrationDown(IMigrationRunner migrationRunner)
    {
        _migrationRunner = migrationRunner;
    }
    
    public void Down(long version)
    {
        _migrationRunner.MigrateDown(version:version);
    }
}