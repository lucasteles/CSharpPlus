using System;
using System.Globalization;

namespace CSharpPlus.JsonConverters.Base;

class JsonEnumMemberValueConverter<TEnum> : JsonEnumCustomStringConverter<TEnum>
    where TEnum : struct, Enum
{
    public JsonEnumMemberValueConverter(StringComparison comparison = StringComparison.Ordinal) :
        base(comparison)
    {
    }

    protected override string GetCustomString(TEnum value) => value.GetEnumMemberValue();

    protected override TEnum? GetValueFromString(string value, StringComparison comparison) =>
        Enumeration.GetEnumFromEnumMemberValue<TEnum>(value, comparison);
}

class JsonEnumDescriptionConverter<TEnum> : JsonEnumCustomStringConverter<TEnum>
    where TEnum : struct, Enum
{
    public JsonEnumDescriptionConverter(StringComparison comparison = StringComparison.Ordinal) :
        base(comparison)
    {
    }

    protected override string GetCustomString(TEnum value) => value.GetDescription();

    protected override TEnum? GetValueFromString(string value, StringComparison comparison) =>
        Enumeration.GetEnumFromDescription<TEnum>(value, comparison);
}

class JsonEnumNumericAsStringConverter<TEnum> : JsonEnumCustomStringConverter<TEnum>
    where TEnum : struct, Enum
{
    public JsonEnumNumericAsStringConverter(StringComparison comparison = StringComparison.Ordinal)
        :
        base(comparison)
    {
    }

    protected override string GetCustomString(TEnum value) =>
        value.ToString("d");

    protected override TEnum? GetValueFromString(string value, StringComparison comparison) =>
        Enum.Parse<TEnum>(value);
}
