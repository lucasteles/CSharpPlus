using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Linq;

/// <summary>
/// String extensions
/// </summary>
public static class StringExtensions
{
    /// <summary>
    /// Indicates whether the specified string is null or an empty string ("").
    /// </summary>
    /// <param name="value">The string to test</param>
    /// <returns>true if the value parameter is null or an empty string (""); otherwise, false.</returns>
    [Pure]
    public static bool IsNullOrEmpty([NotNullWhen(false)] this string? value) =>
        string.IsNullOrEmpty(value);

    /// <summary>
    /// Indicates whether a specified string is null, empty, or consists only of white-space characters.
    /// </summary>
    /// <param name="value">The string to test.</param>
    /// <returns> true if the value parameter is null or Empty, or if value consists exclusively of white-space characters.
    /// </returns>
    [Pure]
    public static bool IsNullOrWhiteSpace([NotNullWhen(false)] this string? value) =>
        string.IsNullOrWhiteSpace(value);

    /// <summary>
    /// Remove all non-digits characters
    /// </summary>
    [Pure]
    public static string RemoveNonDigit(this string value) =>
        new(value.Where(char.IsDigit).ToArray());

    /// <summary>
    /// Remove all non digit or letter characters
    /// </summary>
    [Pure]
    public static string RemoveNonDigitOrLetter(this string value) =>
        new(value.Where(char.IsLetterOrDigit).ToArray());
}
