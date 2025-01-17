using System.ComponentModel;
using System.Reflection;

namespace MigrationRunner.Extensions;

public static class EnumExtension
{
    public static string Description(this Enum value)
    {
        FieldInfo? field = value.GetType().GetField(value.ToString());
        if (field == null)
            throw new ArgumentException("Invalid value");

        DescriptionAttribute attribute = (DescriptionAttribute) field
            .GetCustomAttribute(typeof(DescriptionAttribute))!;

        return attribute is null ? value.ToString() : attribute.Description;
    }
}