namespace CSharpPlus;

/// <summary>
/// Enumerable Plus Extensions
/// </summary>
public static partial class EnumerablePlus
{
    /// <summary>
    /// Concatenates the members of a collection, using the specified separator between each member.
    /// </summary>
    /// <param name="values"></param>
    /// <param name="separator"></param>
    public static string JoinWith<T>(this IEnumerable<T> values, char separator) =>
        string.Join(separator, values);

    /// <summary>
    /// Concatenates the members of a collection, using the specified separator between each member.
    /// </summary>
    /// <param name="values"></param>
    /// <param name="separator"></param>
    public static string JoinWith<T>(this IEnumerable<T> values, string separator) =>
        string.Join(separator, values);

    /// <summary>
    /// Concatenates the members of a collection, using the specified separator between each member.
    /// </summary>
    /// <param name="values"></param>
    public static string JoinWith(this IEnumerable<char> values) =>
        values is char[] array
            ? new(array)
            : string.Join(string.Empty, values);

    /// <summary>
    /// Concatenates the members of a constructed IEnumerable collection of type String.
    /// </summary>
    /// <param name="values"></param>
    /// <returns></returns>
    public static string ConcatString(this IEnumerable<string> values) =>
        string.Concat(values);

    /// <summary>
    /// Concatenates the members of a constructed IEnumerable collection of type String.
    /// </summary>
    /// <param name="values"></param>
    /// <returns></returns>
    public static string ConcatString(this IEnumerable<char> values) =>
        string.Concat(values);
}
