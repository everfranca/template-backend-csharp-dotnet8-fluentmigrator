using FluentMigrator.Runner;

namespace MigrationRunner.Operations.MigrationUp;

public class MigrationUp : IMigrationUp
{
    private readonly IMigrationRunner _migrationRunner;
    public MigrationUp(IMigrationRunner migrationRunner)
    {
        _migrationRunner = migrationRunner;
    }
    
    public void Up()
    {
        _migrationRunner.MigrateUp();
    }
}