using System;
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
    /// Returns a DateOnly instance that is set to the date part of the specified dateTime.
    /// </summary>
    public static DateOnly ToDateOnly(this DateTime dateTime) =>
        DateOnly.FromDateTime(dateTime);

    /// <summary>
    /// Constructs a TimeOnly object from a DateTime representing the time of the day in this DateTime object
    /// </summary>
    public static TimeOnly ToTimeOnly(this DateTime dateTime) =>
        TimeOnly.FromDateTime(dateTime);
}
