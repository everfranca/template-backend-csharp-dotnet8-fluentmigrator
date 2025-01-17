using System.ComponentModel;

namespace MigrationRunner.Enums;

public enum MigrationOperation
{
    [Description("Migration UP")]
    MigrationUp = 1,
    [Description("Migration DOWN")]
    MigrationDown = 2,
    [Description("Migration LIST")]
    MigrationList = 3
}