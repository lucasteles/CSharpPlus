using System.Runtime.CompilerServices;

namespace System.Linq;

/// <summary>
/// Enumerable Plus Extensions
/// </summary>
public static partial class EnumerablePlus
{
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
    public static void Deconstruct<T>(this IEnumerable<T> enumerable, out T t0, out T t1, out T t2,
        out T t3)
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
    public static void Deconstruct<T>(this IEnumerable<T> enumerable,
        out T t0, out T t1, out T t2, out T t3, out T t4)
    {
        var items = TryGetFromEnumerable(enumerable, 5);
        (t0, t1, t2, t3, t4) = (items[0], items[1], items[2], items[3], items[4]);
    }

    /// <summary>
    /// Deconstruct enumerable extracting first five items
    /// </summary>
    /// <param name="enumerable"></param>
    /// <typeparam name="T"></typeparam>
    /// <exception cref="InvalidOperationException">The source sequence dont have 5 or more items</exception>
    public static void Deconstruct<T>(this IEnumerable<T> enumerable,
        out T t0, out T t1, out T t2, out T t3, out T t4, out T t5)
    {
        var items = TryGetFromEnumerable(enumerable, 6);
        (t0, t1, t2, t3, t4, t5) = (items[0], items[1], items[2], items[3], items[4], items[5]);
    }

    static EnumerableItemsArray<T> TryGetFromEnumerable<T>(IEnumerable<T> enumerable, int size)
    {
        ArgumentNullException.ThrowIfNull(enumerable);
        ArgumentOutOfRangeException.ThrowIfNegative(size);

        EnumerableItemsArray<T> result = new();

        var index = 0;

        using var enumerator = enumerable.GetEnumerator();

        while (enumerator.MoveNext() && index < size)
            result[index++] = enumerator.Current;

        if (index < size)
            throw new InvalidOperationException(
                $"The source sequence dont have {size} or more items");

        return result;
    }

    [InlineArray(6)]
    struct EnumerableItemsArray<T>
    {
#pragma warning disable S1144
        T element0;
#pragma warning restore S1144
    }
}
