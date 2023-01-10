using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CSharpPlus.JsonConverters.Base;

abstract class JsonEnumCustomStringConverter<TEnum> : JsonConverter<TEnum>
    where TEnum : struct, Enum
{
    readonly StringComparison comparison;

    protected abstract string GetCustomString(TEnum value);
    protected abstract TEnum? GetValueFromString(string value, StringComparison comparison);

    protected JsonEnumCustomStringConverter(
        StringComparison comparison = StringComparison.Ordinal) =>
        this.comparison = comparison;

    public override void Write(Utf8JsonWriter writer, TEnum value, JsonSerializerOptions options) =>
        writer.WriteStringValue(GetCustomString(value));

    public override TEnum Read(
        ref Utf8JsonReader reader, Type typeToConvert,
        JsonSerializerOptions options)
    {
        if (reader.TokenType is not JsonTokenType.String)
            throw new InvalidOperationException("Invalid enum description");

        var enumString = reader.GetString();

        if (enumString is null ||
            GetValueFromString(enumString, comparison) is not { } value)
            throw new InvalidOperationException("Invalid enum description");

        return value;
    }
}

/// <summary>
/// base string enum converter
/// </summary>
public abstract class JsonEnumCustomStringConverterFactory : JsonConverterFactory
{
    readonly StringComparison comparison;

    /// <summary>
    /// Construct converter
    /// </summary>
    /// <param name="stringComparison" >
    /// string comparison to determine if the string matches
    /// </param>
    protected JsonEnumCustomStringConverterFactory(
        StringComparison stringComparison) =>
        this.comparison = stringComparison;

    /// <summary>
    /// Construct converter
    /// uses string comparison to determine if the string matches
    /// </summary>
    protected JsonEnumCustomStringConverterFactory() : this(StringComparison.Ordinal)
    {
        // An empty constructor is needed for construction via attributes
    }

    /// <inheritdoc />
    public sealed override bool CanConvert(Type typeToConvert) => typeToConvert.IsEnum;

    /// <summary>
    /// Converter Type Factory
    /// </summary>
    /// <param name="typeToConvert"></param>
    /// <returns></returns>
    protected abstract Type GetCustomConverter(Type typeToConvert);

    /// <inheritdoc />
    public sealed override JsonConverter CreateConverter(Type typeToConvert,
        JsonSerializerOptions options) =>
        (JsonConverter)Activator.CreateInstance(GetCustomConverter(typeToConvert), comparison)!;
}
