using System.Collections;
using System.Collections.ObjectModel;

namespace CSharpPlus;

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
    /// Determines whether no element of a sequence satisfies a condition.
    /// </summary>
    public static bool IsEmpty<T>(this IEnumerable<T> @this, Func<T, bool> predicate) => !@this.Any(predicate);

    /// <summary>
    /// Flatten an IEnumerable of sequence and flattens into one sequence.
    /// </summary>
    public static IEnumerable<T> SelectMany<T>(this IEnumerable<IEnumerable<T>> @this) =>
        @this.SelectMany(x => x);

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
    /// Returns the minimum and maximum value in a generic sequence.
    /// </summary>
    public static (T? Min, T? Max) MinAndMax<T>(this IEnumerable<T> @this)
    {
        var items = @this.ToArray();
        return (items.Min(), items.Max());
    }

    /// <summary>
    /// Returns the minimum and maximum value in a generic sequence
    /// </summary>
    public static (TProp? Min, TProp? Max) MinAndMax<T, TProp>(this IEnumerable<T> @this,
        Func<T, TProp> keySelector) =>
        @this.Select(keySelector).MinAndMax();

    /// <summary>
    /// Returns the maximum value in a generic sequence. Defaults if empty
    /// </summary>
    public static TProp MaxOrDefault<T, TProp>(this IEnumerable<T> @this,
        Func<T, TProp> keySelector, TProp value) =>
        @this.Select(keySelector).DefaultIfEmpty(value).Max() ?? value;

    /// <summary>
    /// Returns the maximum value in a generic sequence. Defaults if empty
    /// </summary>
    public static T MaxOrDefault<T>(this IEnumerable<T> @this, T value) =>
        @this.MaxOrDefault(x => x, value);

    /// <summary>
    /// Returns the minimum value in a generic sequence. Defaults if empty
    /// </summary>
    public static TProp MinOrDefault<T, TProp>(
        this IEnumerable<T> @this,
        Func<T, TProp> keySelector, TProp value) =>
        @this.Select(keySelector).DefaultIfEmpty(value).Min() ?? value;

    /// <summary>
    /// Returns the minimum value in a generic sequence. Defaults if empty
    /// </summary>
    public static T MinOrDefault<T>(this IEnumerable<T> @this, T value) =>
        @this.MinOrDefault(x => x, value);

    /// <summary>
    /// Casts Enumerable to nullable value type
    /// </summary>
    public static IEnumerable<T?> ToNullable<T>(this IEnumerable<T> @this) where T : struct =>
        @this.Cast<T?>();

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
    /// Enumerate the source to a collection of value tuples (int Index, T Value)
    /// </summary>
    /// <param name="enumerable"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static IEnumerable<(int Index, T Value)> Enumerate<T>(this IEnumerable<T> enumerable) =>
        enumerable.Select((value, index) => (index, value));


    /// <summary>
    /// Return value as singleton source
    /// </summary>
    /// <param name="item"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns>An source of a single item</returns>
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

    /// <summary>
    /// Produces the set intersection of two sequences according to a specified key selector function.
    /// </summary>
    public static IEnumerable<T> IntersectBy<T, TKey>(this IEnumerable<T> first,
        IEnumerable<T> second, Func<T, TKey> keySelector,
        IEqualityComparer<TKey>? comparer = null) =>
        first.IntersectBy(second.Select(keySelector), keySelector, comparer);

    /// <summary>
    /// Produces the set difference of two sequences according to a specified key selector function.
    /// </summary>
    public static IEnumerable<T> ExceptBy<T, TKey>(this IEnumerable<T> first,
        IEnumerable<T> second, Func<T, TKey> keySelector,
        IEqualityComparer<TKey>? comparer = null) =>
        first.ExceptBy(second.Select(keySelector), keySelector, comparer);

    /// <summary>
    /// Return empty if collection is null
    /// </summary>
    /// <param name="enumerable"></param>
    /// <returns></returns>
    public static IEnumerable<T> EmptyIfNull<T>(this IEnumerable<T>? enumerable) =>
        enumerable ?? [];

    /// <summary>
    /// Return empty if array is null
    /// </summary>
    /// <param name="array"></param>
    /// <returns></returns>
    public static T[] EmptyIfNull<T>(this T[]? array) =>
        array ?? [];

    /// <summary>
    /// Return empty if array is null
    /// </summary>
    /// <param name="array"></param>
    /// <returns></returns>
    public static IReadOnlyCollection<T> EmptyIfNull<T>(this IReadOnlyCollection<T>? array) => array ?? [];

    /// <summary>
    /// Return empty if array is null
    /// </summary>
    /// <param name="array"></param>
    /// <returns></returns>
    public static IReadOnlyList<T> EmptyIfNull<T>(this IReadOnlyList<T>? array) => array ?? [];

    /// <summary>
    /// Creates an IEnumerable from an IEnumerator
    /// </summary>
    public static IEnumerable<T> ToEnumerable<T>(this IEnumerator<T> enumerator)
    {
        using (enumerator)
            while (enumerator.MoveNext())
                yield return enumerator.Current;
    }

    /// <summary>
    /// Creates an IEnumerable from an IEnumerator
    /// </summary>
    public static IEnumerable<object?> ToEnumerable(this IEnumerator enumerator)
    {
        while (enumerator.MoveNext())
            yield return enumerator.Current;
    }

    /// <summary>
    /// Shuffle an source based on a random object
    /// </summary>
    /// <param name="source">The sequence of elements</param>
    /// <param name="random"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns>Shuffled source</returns>
    public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source, Random? random = null)
    {
        ArgumentNullException.ThrowIfNull(source);
        random ??= Random.Shared;

        switch (source)
        {
            case ICollection<T> collection:
                {
                    var copy = collection.ToArray();
                    random.Shuffle(copy);
                    return copy;
                }
            case IReadOnlyCollection<T> readOnly:
                {
                    int count = readOnly.Count;
                    if (count == 0)
                        return Array.Empty<T>();

                    var result = new T[count];
                    var index = 0;
                    foreach (var item in readOnly)
                        result[index++] = item;

                    random.Shuffle(result);
                    return result;
                }
            default:
                return source.OrderBy(_ => random.Next());
        }
    }

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
        ArgumentNullException.ThrowIfNull(source);
        random ??= Random.Shared;
        return source switch
        {
            IReadOnlyCollection<T> { Count: 0 } => defaultValue,
            IReadOnlyList<T> { Count: > 0 } list => list[random.Next(list.Count)],
            _ => source.Shuffle(random).FirstOrDefault(defaultValue),
        };
    }

    /// <summary>
    /// Returns a random item from collection
    /// </summary>
    /// <param name="source">The sequence of elements</param>
    /// <param name="random"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns>Shuffled source</returns>
    public static T PickRandom<T>(this IEnumerable<T> source, Random? random = null)
    {
        ArgumentNullException.ThrowIfNull(source);
        random ??= Random.Shared;
        return source switch
        {
            IReadOnlyList<T> list => list[random.Next(list.Count)],
            _ => source.Shuffle(random).First(),
        };
    }

    /// <summary>
    /// Returns a random subset from collection
    /// </summary>
    public static IReadOnlyList<T> PickRandom<T>(
        this IEnumerable<T> source,
        int length,
        Random? random = null)
    {
        ArgumentNullException.ThrowIfNull(source);
        ArgumentOutOfRangeException.ThrowIfNegative(length);

        random ??= Random.Shared;

        return source switch
        {
            IReadOnlyCollection<T> { Count: 0 } => [],
            T[] { Length: > 0 } arr => random.GetItems(arr, length),
            ICollection<T> { Count: > 0 } collection => random.GetItems(collection.ToArray(), length),
            _ => source.Shuffle(random).Take(length).ToArray(),
        };
    }

    /// <summary>
    /// Lazily run action when the enumerable is evaluated
    /// </summary>
    public static IEnumerable<T> Tap<T>(this IEnumerable<T> @this, Action<T> action)
    {
        foreach (var item in @this)
        {
            action(item);
            yield return item;
        }
    }
}
