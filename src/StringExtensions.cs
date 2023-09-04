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


    /// <summary>
    /// Returns a persistent hashcode for the string
    /// </summary>
    [Pure]
    public static int GetStableHashCode(this string str)
    {
        unchecked
        {
            int hash1 = 5381;
            int hash2 = hash1;

            for (int i = 0; i < str.Length && str[i] != '\0'; i += 2)
            {
                hash1 = ((hash1 << 5) + hash1) ^ str[i];
                if (i == str.Length - 1 || str[i + 1] == '\0')
                    break;
                hash2 = ((hash2 << 5) + hash2) ^ str[i + 1];
            }

            return hash1 + (hash2 * 1566083941);
        }
    }
}
