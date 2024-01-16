using System.Globalization;
using System.Numerics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CSharpPlus.JsonConverters;

/// <summary>
/// Json converter for System.Numerics.BigInteger
/// </summary>
public class BigIntegerJsonConverter : JsonConverter<BigInteger>
{
    /// <inheritdoc />
    public override BigInteger Read(ref Utf8JsonReader reader, Type typeToConvert,
        JsonSerializerOptions options)
    {
        if (reader.TokenType is not (JsonTokenType.Number or JsonTokenType.String))
            throw new JsonException(
                $"Found token {reader.TokenType} but expected token {JsonTokenType.Number}");

        using var doc = JsonDocument.ParseValue(ref reader);
        var value = reader.TokenType == JsonTokenType.String
            ? doc.RootElement.GetString() ?? "0"
            : doc.RootElement.GetRawText();

        var bigInteger = BigInteger.Parse(value, NumberFormatInfo.InvariantInfo);
        return bigInteger;
    }

    /// <inheritdoc />
    public override void Write(Utf8JsonWriter writer, BigInteger value,
        JsonSerializerOptions options)
    {
        var result = value.ToString(NumberFormatInfo.InvariantInfo);
        writer.WriteRawValue(result);
    }
}
