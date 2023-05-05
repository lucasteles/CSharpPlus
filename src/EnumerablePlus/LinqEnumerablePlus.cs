using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace System.Linq;

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
    public static (T? Min, T? Max) MinAndMaxBy<T, TProp>(this IEnumerable<T> @this,
        Func<T, TProp> keySelector)
    {
        var items = @this.ToArray();
        return (items.MinBy(keySelector), items.MaxBy(keySelector));
    }

    /// <summary>
    /// Returns the minimum and maximum value in a generic sequence
    /// </summary>
    public static (TProp? Min, TProp? Max) MinAndMax<T, TProp>(this IEnumerable<T> @this,
        Func<T, TProp> keySelector)
    {
        var items = @this.ToArray();
        return (items.Min(keySelector), items.Max(keySelector));
    }

    /// <summary>
    /// Returns the maximum value in a generic sequence. Defaults if empty
    /// </summary>
    public static TProp? MaxOrDefault<T, TProp>(this IEnumerable<T> @this,
        Func<T, TProp> keySelector,
        TProp? value = default) =>
        @this.Select(keySelector).DefaultIfEmpty(value).Max();

    /// <summary>
    /// Returns the minimum value in a generic sequence. Defaults if empty
    /// </summary>
    public static TProp? MinOrDefault<T, TProp>(this IEnumerable<T> @this,
        Func<T, TProp> keySelector,
        TProp? value = default) =>
        @this.Select(keySelector).DefaultIfEmpty(value).Min();

    /// <summary>
    /// Filter non-null items
    /// </summary>
    /// <param name="enumerable"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static IEnumerable<T> WhereNotNull<T>(this IEnumerable<T?> enumerable) where T : class =>
        enumerable.Where(e => e is not null).Cast<T>();

    /// <summary>
    /// Filter non-null items
    /// </summary>
    /// <param name="enumerable"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static IEnumerable<T> WhereNotNull<T>(this IEnumerable<T?> enumerable)
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

    /// <summary>
    /// Shuffle an enumerable based on a random object
    /// </summary>
    /// <param name="source">The sequence of elements</param>
    /// <param name="random"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns>Shuffled enumerable</returns>
    public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source, Random? random = null) =>
        source.OrderBy(_ => (random ?? Random.Shared).Next());

    /// <summary>
    /// Returns a random item from collection
    /// </summary>
    /// <param name="source">The sequence of elements</param>
    /// <param name="defaultValue"></param>
    /// <param name="random"></param>
    /// <typeparam name="T"></typeparam>
    public static T? PickRandomOrDefault<T>(this IEnumerable<T> source,
        T? defaultValue = default, Random? random = null)
    {
        var rnd = random ?? Random.Shared;
        return source switch
        {
            IReadOnlyCollection<T> { Count: 0 } => default,
            IReadOnlyList<T> { Count: > 0 } list => list[rnd.Next(list.Count)],
            _ => source.Shuffle(rnd).FirstOrDefault(defaultValue),
        };
    }

    /// <summary>
    /// Returns a random item from collection
    /// </summary>
    /// <param name="source">The sequence of elements</param>
    /// <param name="random"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns>Shuffled enumerable</returns>
    public static T PickRandom<T>(this IEnumerable<T> source, Random? random = null)
    {
        var rnd = random ?? Random.Shared;
        return source switch
        {
            IReadOnlyList<T> list => list[rnd.Next(list.Count)],
            _ => source.Shuffle(rnd).First(),
        };
    }

    /// <summary>
    /// Creates a IReadOnlyList from a IEnumerable.
    /// </summary>
    /// <param name="enumerable"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static IReadOnlyList<T> ToReadOnlyList<T>(this IEnumerable<T> enumerable) =>
        enumerable switch
        {
            null => Array.Empty<T>(),
            IList<T> list => new ReadOnlyCollection<T>(list),
            _ => Array.AsReadOnly(enumerable.ToArray()),
        };

    /// <summary>
    /// Creates a IReadOnlyCollection from a IEnumerable.
    /// </summary>
    /// <param name="enumerable"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static IReadOnlyCollection<T> ToReadOnly<T>(this IEnumerable<T> enumerable) =>
        enumerable.ToReadOnlyList();
}
