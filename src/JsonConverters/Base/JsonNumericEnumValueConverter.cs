using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CSharpPlus.JsonConverters.Base;

class JsonNumericEnumValueConverter<TEnum> : JsonConverter<TEnum>
    where TEnum : struct, Enum
{
    readonly Type underlyingType;

    public JsonNumericEnumValueConverter() =>
        underlyingType = Enum.GetUnderlyingType(typeof(TEnum));

    public override void Write(Utf8JsonWriter writer, TEnum value, JsonSerializerOptions options)
    {
        var box = (object)value;
        if (underlyingType == typeof(int)) writer.WriteNumberValue((int)box);
        else if (underlyingType == typeof(uint)) writer.WriteNumberValue((uint)box);
        else if (underlyingType == typeof(long)) writer.WriteNumberValue((long)box);
        else if (underlyingType == typeof(ulong)) writer.WriteNumberValue((ulong)box);
        else if (underlyingType == typeof(byte)) writer.WriteNumberValue((byte)box);
        else if (underlyingType == typeof(sbyte)) writer.WriteNumberValue((sbyte)box);
        else if (underlyingType == typeof(short)) writer.WriteNumberValue((short)box);
        else if (underlyingType == typeof(ushort)) writer.WriteNumberValue((ushort)box);
        else
            throw new InvalidOperationException(
                $"Writing {value} to numeric enum {typeof(TEnum).Name} as {underlyingType.Name}");
    }

    public override TEnum Read(ref Utf8JsonReader reader, Type typeToConvert,
        JsonSerializerOptions options)
    {
        if (underlyingType == typeof(int)) return (TEnum)(object)reader.GetInt32();
        if (underlyingType == typeof(uint)) return (TEnum)(object)reader.GetUInt32();
        if (underlyingType == typeof(long)) return (TEnum)(object)reader.GetInt64();
        if (underlyingType == typeof(ulong)) return (TEnum)(object)reader.GetUInt64();
        if (underlyingType == typeof(byte)) return (TEnum)(object)reader.GetByte();
        if (underlyingType == typeof(sbyte)) return (TEnum)(object)reader.GetSByte();
        if (underlyingType == typeof(short)) return (TEnum)(object)reader.GetInt16();
        if (underlyingType == typeof(ushort)) return (TEnum)(object)reader.GetUInt16();
        throw new InvalidOperationException(
            $"Reading {reader.GetString()} to numeric enum {typeof(TEnum).Name} as {underlyingType.Name}");
    }
}
