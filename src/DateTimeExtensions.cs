using System.Globalization;

namespace CSharpPlus;

/// <summary>
/// DateTime Extensions
/// </summary>
public static class DateTimeExtensions
{
    /// <summary>
    /// Initializes a new instance of the DateTimeOffset structure using the specified DateTime value and offset
    /// </summary>
    public static DateTimeOffset WithOffset(this DateTime dateTime, TimeSpan offset) =>
        new(dateTime, offset);

    /// <summary>
    /// Returns the number of seconds that have elapsed since 1970-01-01T00:00:00Z
    /// </summary>
    public static long ToUnixTimeSeconds(this DateTime dateTime) =>
        new DateTimeOffset(dateTime).ToUnixTimeSeconds();

    /// <summary>
    /// Returns the number of seconds that have elapsed since 1970-01-01T00:00:00Z
    /// </summary>
    public static long ToUnixTimeSeconds(this DateOnly dateTime) =>
        new DateTimeOffset(dateTime.ToDateTime()).ToUnixTimeSeconds();

    /// <summary>
    /// DateOnly string Invariant IS8601 string
    /// </summary>
    public static string ToIsoString(this DateOnly dateOnly) =>
        dateOnly.ToString("O", CultureInfo.InvariantCulture);

    /// <summary>
    /// DateTime Invariant IS8601 string
    /// </summary>
    public static string ToIsoString(this DateTime date) =>
        date.ToString("O", CultureInfo.InvariantCulture);

    /// <summary>
    /// DateTime Invariant IS8601 string
    /// </summary>
    public static string ToIsoString(this DateTimeOffset date) =>
        date.ToString("O", CultureInfo.InvariantCulture);

    /// <summary>
    /// Returns a DateOnly instance that is set to the date part of the specified dateOnly.
    /// </summary>
    public static DateOnly ToDateOnly(this DateTime dateTime) =>
        DateOnly.FromDateTime(dateTime);

    /// <summary>
    /// Returns a DateOnly instance that is set to the date part of the specified dateOnly.
    /// </summary>
    public static DateOnly ToDateOnly(this DateTimeOffset dateTime) =>
        DateOnly.FromDateTime(dateTime.DateTime);

    /// <summary>
    /// Constructs a TimeOnly object from a DateTime representing the time of the day in this DateTime object
    /// </summary>
    public static TimeOnly ToTimeOnly(this DateTime dateTime) =>
        TimeOnly.FromDateTime(dateTime);

    /// <summary>
    /// Constructs a TimeOnly object from a time span representing the time elapsed since midnight.
    /// </summary>
    public static TimeOnly ToTimeOnly(this TimeSpan span) =>
        TimeOnly.FromTimeSpan(span);

    /// <summary>
    /// Returns a DateTime instance with the specified input kind that is set to the date of this DateOnly instance and the time at UTC 00:00AM.
    /// </summary>
    public static DateTime ToDateTime(this DateOnly dateOnly) =>
        dateOnly.ToDateTime(default, DateTimeKind.Utc);

    /// <summary>
    /// Returns a DateTime instance with the specified input kind that is set to the date of this DateOnly instance and the time at 00:00AM.
    /// </summary>
    public static DateTime ToDateTime(this DateOnly dateOnly, DateTimeKind kind) =>
        dateOnly.ToDateTime(default, kind);

    /// <summary>
    /// Returns a DateTime instance with the specified input kind that is set to the date of this DateOnly instance and a TimeSpan
    /// </summary>
    public static DateTime ToDateTime(this DateOnly dateOnly, TimeSpan span,
        DateTimeKind kind = DateTimeKind.Utc) =>
        dateOnly.ToDateTime(span.ToTimeOnly(), kind);

    /// <summary>
    /// Returns current DateTime in UTC
    /// </summary>
    public static DateTime UtcNow(this TimeProvider provider) =>
        provider.GetUtcNow().DateTime;

    /// <summary>
    /// Returns current local DateTime
    /// </summary>
    public static DateTime Now(this TimeProvider provider) =>
        provider.GetLocalNow().DateTime;

    /// <summary>
    /// Returns current DateOnly
    /// </summary>
    public static DateOnly Today(this TimeProvider provider) =>
        provider.GetUtcNow().ToDateOnly();
}
