using System.ComponentModel;

namespace MigrationRunner.Enums;

public enum UserResponseType
{
    [Description("Sim")]
    Yes = 1,
    [Description("Não")]
    No = 2
}