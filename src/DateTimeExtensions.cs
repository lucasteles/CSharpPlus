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
    /// <param name="dateTime"></param>
    /// <returns></returns>
    public static string ToJsonString(this DateTime dateTime) =>
        JsonSerializer.Serialize(dateTime)[1..^1];
}
