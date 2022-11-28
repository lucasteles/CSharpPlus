using System;
using System.Text.Json;

namespace CSharpPlus.JsonConverters;

using System.Text.Json.Serialization;

abstract class EnumCustomStringConverter<TEnum> : JsonConverter<TEnum> where TEnum : struct, Enum
{
    readonly StringComparison comparison;

    protected abstract string GetCustomString(TEnum value);
    protected abstract TEnum? GetValueFromString(string value, StringComparison comparison);

    protected EnumCustomStringConverter(StringComparison comparison = StringComparison.Ordinal) =>
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

class EnumDescriptionConverter<TEnum> : EnumCustomStringConverter<TEnum> where TEnum : struct, Enum
{
    public EnumDescriptionConverter(StringComparison comparison = StringComparison.Ordinal) :
        base(comparison)
    {
    }

    protected override string GetCustomString(TEnum value) => value.GetDescription();

    protected override TEnum? GetValueFromString(string value, StringComparison comparison) =>
        Enumeration.GetEnumFromDescription<TEnum>(value, comparison);
}

class EnumMemberValueConverter<TEnum> : EnumCustomStringConverter<TEnum> where TEnum : struct, Enum
{
    public EnumMemberValueConverter(StringComparison comparison = StringComparison.Ordinal) :
        base(comparison)
    {
    }

    protected override string GetCustomString(TEnum value) => value.GetEnumMemberValue();

    protected override TEnum? GetValueFromString(string value, StringComparison comparison) =>
        Enumeration.GetEnumFromEnumMemberValue<TEnum>(value, comparison);
}
