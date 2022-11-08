using System;
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


    /// <summary>
    /// determines whether a sequence contains no elements.
    /// </summary>
    /// <param name="this"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static bool IsEmpty<T>(this IEnumerable<T> @this) => !@this.Any();

    /// <summary>
    /// Flatten an IEnumerable of sequence and flattens into one sequence.
    /// </summary>
    /// <param name="this"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
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
    public static (T? Min, T? Max) MinMaxBy<T, TProp>(this IEnumerable<T> @this, Func<T, TProp> keySelector)
    {
        var items = @this.ToArray();
        return (items.MinBy(keySelector), items.MaxBy(keySelector));
    }


    /// <summary>
    /// Deconstruct enumerable extracting first item
    /// </summary>
    /// <param name="enumerable"></param>
    /// <param name="t0"></param>
    /// <typeparam name="T"></typeparam>
    /// <exception cref="InvalidOperationException">The source sequence is empty.</exception>
    public static void Deconstruct<T>(this IEnumerable<T> enumerable, out T t0)
    {
        var item = enumerable.First();
        t0 = item;
    }

    /// <summary>
    /// Deconstruct enumerable extracting first two items
    /// </summary>
    /// <param name="enumerable"></param>
    /// <param name="t0"></param>
    /// <param name="t1"></param>
    /// <typeparam name="T"></typeparam>
    /// <exception cref="InvalidOperationException">The source sequence dont have 2 or more items</exception>
    public static void Deconstruct<T>(this IEnumerable<T> enumerable, out T t0, out T t1)
    {
        var items = TryGetFromEnumerable(enumerable, 2);

        (t0, t1) = (items[0], items[1]);
    }


    /// <summary>
    /// Deconstruct enumerable extracting first three items
    /// </summary>
    /// <param name="enumerable"></param>
    /// <param name="t0"></param>
    /// <param name="t1"></param>
    /// <param name="t2"></param>
    /// <typeparam name="T"></typeparam>
    /// <exception cref="InvalidOperationException">The source sequence dont have 3 or more items</exception>
    public static void Deconstruct<T>(this IEnumerable<T> enumerable, out T t0, out T t1, out T t2)
    {
        var items = TryGetFromEnumerable(enumerable, 3);
        (t0, t1, t2) = (items[0], items[1], items[2]);
    }

    /// <summary>
    /// Deconstruct enumerable extracting first four items
    /// </summary>
    /// <param name="enumerable"></param>
    /// <param name="t0"></param>
    /// <param name="t1"></param>
    /// <param name="t2"></param>
    /// <param name="t3"></param>
    /// <typeparam name="T"></typeparam>
    /// <exception cref="InvalidOperationException">The source sequence dont have 4 or more items</exception>
    public static void Deconstruct<T>(this IEnumerable<T> enumerable, out T t0, out T t1, out T t2, out T t3)
    {
        var items = TryGetFromEnumerable(enumerable, 4);
        (t0, t1, t2, t3) = (items[0], items[1], items[2], items[3]);
    }

    /// <summary>
    /// Deconstruct enumerable extracting first five items
    /// </summary>
    /// <param name="enumerable"></param>
    /// <param name="t0"></param>
    /// <param name="t1"></param>
    /// <param name="t2"></param>
    /// <param name="t3"></param>
    /// <param name="t4"></param>
    /// <typeparam name="T"></typeparam>
    /// <exception cref="InvalidOperationException">The source sequence dont have 5 or more items</exception>
    public static void Deconstruct<T>(this IEnumerable<T> enumerable, out T t0, out T t1, out T t2, out T t3, out T t4)
    {
        var items = TryGetFromEnumerable(enumerable, 5);
        (t0, t1, t2, t3, t4) = (items[0], items[1], items[2], items[3], items[4]);
    }

    static T[] TryGetFromEnumerable<T>(IEnumerable<T> enumerable, int size)
    {
        var items = enumerable.Take(size).ToArray();
        if (items.Length < size)
            throw new InvalidOperationException(
                $"The source sequence dont have {size} or more items");
        return items;
    }
}
