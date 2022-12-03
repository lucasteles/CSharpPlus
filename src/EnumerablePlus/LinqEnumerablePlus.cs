using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Enumerable Plus Extensions
/// </summary>
public static partial class EnumerablePlus
{
    /// <summary>
    /// determines whether a sequence contains no elements.
    /// </summary>
    public static bool IsEmpty<T>(this IEnumerable<T> @this) => !@this.Any();

    /// <summary>
    /// Flatten an IEnumerable of sequence and flattens into one sequence.
    /// </summary>
    public static IEnumerable<T> SelectMany<T>(this IEnumerable<IEnumerable<T>> @this) =>
        @this.SelectMany(x => x);

    /// <summary>
    /// Returns the minimum and maximum value in a generic sequence.
    /// </summary>
    public static (T? Min, T? Max) MinMax<T>(this IEnumerable<T> @this)
    {
        var items = @this.ToArray();
        return (items.Min(), items.Max());
    }

    /// <summary>
    /// Returns the minimum and maximum value in a generic sequence by key member.
    /// </summary>
    public static (T? Min, T? Max) MinMaxBy<T, TProp>(this IEnumerable<T> @this,
        Func<T, TProp> keySelector)
    {
        var items = @this.ToArray();
        return (items.MinBy(keySelector), items.MaxBy(keySelector));
    }

    /// <summary>
    /// Filter non-null items
    /// </summary>
    /// <param name="enumerable"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static IEnumerable<T> NotNullOnly<T>(this IEnumerable<T?> enumerable) where T : class =>
        enumerable.Where(e => e is not null).Cast<T>();

    /// <summary>
    /// Filter non-null items
    /// </summary>
    /// <param name="enumerable"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static IEnumerable<T> NotNullOnly<T>(this IEnumerable<T?> enumerable)
        where T : struct =>
        enumerable.Where(e => e is not null).Select(e => e!.Value);


    /// <summary>
    /// Enumerate the enumerable to a collection of value tuples (int Index, T Value)
    /// </summary>
    /// <param name="enumerable"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static IEnumerable<(int Index, T Value)> Enumerate<T>(this IEnumerable<T> enumerable) =>
        enumerable.Select((value, index) => (index, value));


    /// <summary>
    /// Return value as singleton enumerable
    /// </summary>
    /// <param name="item"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns>An enumerable of a single item</returns>
    public static IEnumerable<T> ToSingleton<T>(this T item) =>
        Enumerable.Repeat(item, 1);

    /// <summary>
    /// Eagerly executes the given action on each element in the sequence.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the sequence</typeparam>
    /// <param name="source">The sequence of elements</param>
    /// <param name="action">The action to execute on each element</param>
    public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
    {
        ArgumentNullException.ThrowIfNull(source);
        ArgumentNullException.ThrowIfNull(action);
        foreach (var element in source)
            action(element);
    }

    /// <summary>
    /// Eagerly executes the given action on each element in the indexed sequence.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the sequence</typeparam>
    /// <param name="source">The sequence of elements</param>
    /// <param name="action">The action to execute on each element; the second parameter
    /// of the action represents the index of the source element.</param>
    public static void ForEach<T>(this IEnumerable<T> source, Action<T, int> action)
    {
        ArgumentNullException.ThrowIfNull(source);
        ArgumentNullException.ThrowIfNull(action);
        foreach (var (index, item) in source.Enumerate())
            action(item, index);
    }
}
