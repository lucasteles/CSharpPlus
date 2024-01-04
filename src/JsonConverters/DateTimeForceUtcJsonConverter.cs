// ReSharper disable once CheckNamespace

namespace System.Text.Json.Serialization;

/// <summary>
/// Json converter for DateTime forcing UTC
/// </summary>
public class DateTimeForceUtcJsonConverter : JsonConverter<DateTime>
{
    readonly TimeSpan offset;

    /// <summary>
    /// Convert DateTime always in UTC Kind
    /// </summary>
    /// <param name="offset">Custom timespan offset for DateTimeKind.Unspecified</param>
    public DateTimeForceUtcJsonConverter(TimeSpan offset) => this.offset = offset;

    /// <summary>
    /// Convert DateTime always in UTC Kind
    /// </summary>
    /// <param name="timeZone">time zone to use when DateTimeKind.Unspecified</param>
    public DateTimeForceUtcJsonConverter(TimeZoneInfo? timeZone = null) =>
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
#pragma warning disable S112
            _ => throw new IndexOutOfRangeException(nameof(DateTime.Kind)),
#pragma warning restore S112
        };

    /// <inheritdoc />
    public override void Write(Utf8JsonWriter writer, DateTime value,
        JsonSerializerOptions options) =>
        writer.WriteStringValue(value.ToUniversalTime());
}
