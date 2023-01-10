using CSharpPlus.JsonConverters.Base;

// ReSharper disable once CheckNamespace
namespace System.Text.Json.Serialization;

using System;

/// <summary>
/// Converter for json using description attribute
/// </summary>
public sealed class JsonDescriptionEnumConverter : JsonEnumCustomStringConverterFactory
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
        typeof(JsonEnumDescriptionConverter<>)
            .MakeGenericType(typeToConvert);
}

/// <summary>
/// Converter for json using description attribute
/// </summary>
public sealed class JsonEnumMemberValueConverter : JsonEnumCustomStringConverterFactory
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
        typeof(JsonEnumMemberValueConverter<>)
            .MakeGenericType(typeToConvert);
}

/// <summary>
/// Converter for json using description attribute
/// </summary>
public sealed class JsonEnumNumericAsStringConverter : JsonEnumCustomStringConverterFactory
{
    /// <inheritdoc />
    public JsonEnumNumericAsStringConverter() : base(StringComparison.Ordinal)
    {
    }

    /// <inheritdoc />
    protected override Type GetCustomConverter(Type typeToConvert) =>
        typeof(JsonEnumNumericAsStringConverter<>)
            .MakeGenericType(typeToConvert);
}

/// <summary>
/// Converter for json using description attribute
/// </summary>
public sealed class JsonNumericEnumConverter : JsonConverterFactory
{
    /// <inheritdoc />
    public override bool CanConvert(Type typeToConvert) => typeToConvert.IsEnum;

    /// <inheritdoc />
    public override JsonConverter CreateConverter(
        Type typeToConvert, JsonSerializerOptions options) =>
        (JsonConverter)Activator.CreateInstance(
            typeof(JsonNumericEnumValueConverter<>)
                .MakeGenericType(typeToConvert))!;
}
