using System;
using System.Globalization;
using System.Text.Json;

/// <summary>
/// DateTime Extensions
/// </summary>
public static class DateTimeExtensions
{
    /// <summary>
    /// Format date as default System.Text.Json format
    /// </summary>
    public static string ToJsonString(this DateTime dateTime) =>
        JsonSerializer.Serialize(dateTime)[1..^1];

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
    /// Returns a DateOnly instance that is set to the date part of the specified dateOnly.
    /// </summary>
    public static DateOnly ToDateOnly(this DateTime dateTime) =>
        DateOnly.FromDateTime(dateTime);

    /// <summary>
    /// Constructs a TimeOnly object from a DateTime representing the time of the day in this DateTime object
    /// </summary>
    public static TimeOnly ToTimeOnly(this DateTime dateTime) =>
        TimeOnly.FromDateTime(dateTime);


    /// <summary>
    /// Returns a DateTime instance with the specified input kind that is set to the date of this DateOnly instance and the time at 00:00AM.
    /// </summary>
    public static DateTime
        ToDateTime(this DateOnly dateOnly, DateTimeKind kind = DateTimeKind.Utc) =>
        dateOnly.ToDateTime(new(), kind);
}
