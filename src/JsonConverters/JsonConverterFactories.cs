namespace System.Text.Json.Serialization;

using CSharpPlus.JsonConverters;
using System;

/// <summary>
/// Converter for json using description attribute
/// </summary>
public sealed class JsonDescriptionEnumConverter : JsonCustomStringEnumConverter
{
    /// <inheritdoc />
    public JsonDescriptionEnumConverter(StringComparison comparison) :
        base(comparison)
    {
    }

    /// <inheritdoc />
    public JsonDescriptionEnumConverter() :
        base(StringComparison.Ordinal)
    {
    }

    /// <inheritdoc />
    protected override Type GetCustomConverter(Type typeToConvert) =>
        typeof(EnumDescriptionConverter<>)
            .MakeGenericType(typeToConvert);
}

/// <summary>
/// Converter for json using description attribute
/// </summary>
public sealed class JsonEnumMemberValueConverter : JsonCustomStringEnumConverter
{
    /// <inheritdoc />
    public JsonEnumMemberValueConverter(StringComparison comparison) :
        base(comparison)
    {
    }

    /// <inheritdoc />
    public JsonEnumMemberValueConverter() :
        base(StringComparison.Ordinal)
    {
    }

    /// <inheritdoc />
    protected override Type GetCustomConverter(Type typeToConvert) =>
        typeof(EnumMemberValueConverter<>)
            .MakeGenericType(typeToConvert);
}
