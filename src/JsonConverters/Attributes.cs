namespace System.Text.Json.Serialization;

/// <summary>
/// Sets enum to use description for json serialization
/// </summary>
[AttributeUsage(AttributeTargets.Enum)]
public sealed class UseJsonEnumDescriptionAttribute : JsonConverterAttribute
{
    /// <inheritdoc />
    public UseJsonEnumDescriptionAttribute() :
        base(typeof(JsonDescriptionEnumConverter))
    {
    }
}

/// <summary>
/// Sets enum to use enum member value for json serialization
/// </summary>
[AttributeUsage(AttributeTargets.Enum)]
public sealed class UseJsonEnumMemberValueAttribute : JsonConverterAttribute
{
    /// <inheritdoc />
    public UseJsonEnumMemberValueAttribute() : base(typeof(JsonEnumMemberValueConverter))
    {
    }
}
