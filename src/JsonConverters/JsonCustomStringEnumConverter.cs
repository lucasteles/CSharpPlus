using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CSharpPlus.JsonConverters;

/// <summary>
/// base string enum converter
/// </summary>
public abstract class JsonCustomStringEnumConverter : JsonConverterFactory
{
    readonly StringComparison comparison;

    /// <summary>
    /// Construct converter
    /// </summary>
    /// <param name="stringComparison" >
    /// string comparison to determine if the string matches
    /// </param>
    protected JsonCustomStringEnumConverter(
        StringComparison stringComparison) =>
        this.comparison = stringComparison;

    /// <summary>
    /// Construct converter
    /// uses string comparison to determine if the string matches
    /// </summary>
    protected JsonCustomStringEnumConverter() : this(StringComparison.Ordinal)
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
