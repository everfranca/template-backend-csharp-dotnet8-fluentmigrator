namespace MigrationRunner.Operations.MigrationDown;

public interface IMigrationDown
{
    void Down(long version);
}