// ReSharper disable once CheckNamespace

namespace System.Text.Json.Serialization;

/// <summary>
/// Json converter for DateTime forcing UTC
/// </summary>
public class DateTimeUtcOnlyJsonConverter : JsonConverter<DateTime>
{
    readonly TimeSpan offset;

    /// <summary>
    /// Convert DateTime always in UTC Kind
    /// </summary>
    /// <param name="offset">Custom timespan offset for DateTimeKind.Unspecified</param>
    public DateTimeUtcOnlyJsonConverter(TimeSpan offset) => this.offset = offset;

    /// <summary>
    /// Convert DateTime always in UTC Kind
    /// </summary>
    /// <param name="timeZone">time zone to use when DateTimeKind.Unspecified</param>
    public DateTimeUtcOnlyJsonConverter(TimeZoneInfo? timeZone = null) =>
        offset = timeZone?.BaseUtcOffset ?? TimeZoneInfo.Utc.BaseUtcOffset;

    /// <inheritdoc />
    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert,
        JsonSerializerOptions options) =>
        reader.GetDateTime() switch
        {
            { Kind: DateTimeKind.Utc } utcDate => utcDate,
            { Kind: DateTimeKind.Local } localDate => localDate.ToUniversalTime(),
            { Kind: DateTimeKind.Unspecified } date => new DateTimeOffset(date.Ticks, offset)
                .UtcDateTime,
            _ => throw new IndexOutOfRangeException(nameof(DateTime.Kind))
        };

    /// <inheritdoc />
    public override void Write(Utf8JsonWriter writer, DateTime value,
        JsonSerializerOptions options) =>
        writer.WriteStringValue(value.ToUniversalTime());
}
