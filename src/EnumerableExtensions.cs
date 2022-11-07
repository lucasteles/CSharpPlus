using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Enumerable Extensions
/// </summary>
public static class EnumerableExtensions
{
    /// <summary>
    /// Concatenates the members of a collection, using the specified separator between each member.
    /// </summary>
    /// <param name="values"></param>
    /// <param name="separator"></param>
    public static string JoinString(this IEnumerable<string> values, char separator) => string.Join(separator, values);

    /// <summary>
    /// Concatenates the members of a collection, using the specified separator between each member.
    /// </summary>
    /// <param name="values"></param>
    /// <param name="separator"></param>
    public static string JoinString(this IEnumerable<string> values, string separator) =>
        string.Join(separator, values);

    /// <summary>
    /// Concatenates the members of a collection, using the specified separator between each member.
    /// </summary>
    /// <param name="values"></param>
    /// <param name="separator"></param>
    public static string JoinString(this IEnumerable<char> values, char separator) => string.Join(separator, values);

    /// <summary>
    /// Concatenates the members of a collection, using the specified separator between each member.
    /// </summary>
    /// <param name="values"></param>
    /// <param name="separator"></param>
    public static string JoinString(this IEnumerable<char> values, string separator) => string.Join(separator, values);


    /// <summary>
    /// Concatenates the members of a constructed IEnumerable<out T> collection of type String.
    /// </summary>
    /// <param name="values"></param>
    /// <returns></returns>
    public static string ConcatString(this IEnumerable<string> values) =>
        string.Concat(values);

    /// <summary>
    /// Concatenates the members of a constructed IEnumerable<out T> collection of type String.
    /// </summary>
    /// <param name="values"></param>
    /// <returns></returns>
    public static string ConcatString(this IEnumerable<char> values) =>
        string.Concat(values);


    /// <summary>
    /// Determines whether a sequence contains no elements.
    /// </summary>
    /// <param name="this"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static bool IsEmpty<T>(this IEnumerable<T> @this) => !@this.Any();
}
