using System.ComponentModel;

namespace MigrationRunner.Enums;

public enum ApplicationEnvironment
{
    [Description("Development or Local")]
    Development = 1,
    [Description("Staging")]
    Staging = 2,
    [Description("Production")]
    Production = 3
}