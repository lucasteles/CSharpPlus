// ReSharper disable once CheckNamespace

namespace System.Text.Json.Serialization;

/// <summary>
/// Sets enum to use default string value for json serialization
/// </summary>
[AttributeUsage(AttributeTargets.Enum)]
public sealed class JsonEnumStringAttribute : JsonConverterAttribute
{
    /// <inheritdoc />
    public JsonEnumStringAttribute() : base(typeof(JsonStringEnumConverter))
    {
    }
}

/// <summary>
/// Sets enum to use description for json serialization
/// </summary>
[AttributeUsage(
    AttributeTargets.Class | AttributeTargets.Interface | AttributeTargets.Struct |
    AttributeTargets.Enum | AttributeTargets.Property | AttributeTargets.Field)]
public sealed class JsonEnumDescriptionAttribute : JsonConverterAttribute
{
    /// <inheritdoc />
    public JsonEnumDescriptionAttribute() :
        base(typeof(JsonDescriptionEnumConverter))
    {
    }
}

/// <summary>
/// Sets enum to use enum member value for json serialization
/// </summary>
[AttributeUsage(
    AttributeTargets.Class | AttributeTargets.Interface | AttributeTargets.Struct |
    AttributeTargets.Enum | AttributeTargets.Property | AttributeTargets.Field)]
public sealed class JsonEnumMemberValueAttribute : JsonConverterAttribute
{
    /// <inheritdoc />
    public JsonEnumMemberValueAttribute() : base(typeof(JsonEnumMemberValueConverter))
    {
    }
}

/// <summary>
/// Sets enum to use string numeric values, for json serialization
/// </summary>
[AttributeUsage(
    AttributeTargets.Class | AttributeTargets.Interface | AttributeTargets.Struct |
    AttributeTargets.Enum | AttributeTargets.Property | AttributeTargets.Field)]
public sealed class JsonEnumNumericAsStringAttribute : JsonConverterAttribute
{
    /// <inheritdoc />
    public JsonEnumNumericAsStringAttribute() : base(typeof(JsonEnumNumericAsStringConverter))
    {
    }
}

/// <summary>
/// Sets enum to use numeric values for json serialization
/// </summary>
[AttributeUsage(
    AttributeTargets.Class | AttributeTargets.Interface | AttributeTargets.Struct |
    AttributeTargets.Enum | AttributeTargets.Property | AttributeTargets.Field)]
public sealed class JsonEnumNumericAttribute : JsonConverterAttribute
{
    /// <inheritdoc />
    public JsonEnumNumericAttribute() : base(typeof(JsonNumericEnumConverter))
    {
    }
}
