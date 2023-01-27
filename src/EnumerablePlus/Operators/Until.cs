using System;
using System.Collections.Generic;

public static partial class EnumerablePlus
{
    /// <summary>
    /// Take until item satisfies the predicate (inclusive)
    /// </summary>
    /// <param name="source"></param>
    /// <param name="predicate"></param>
    /// <typeparam name="TSource"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static IEnumerable<TSource> TakeUntil<TSource>(
        this IEnumerable<TSource> source,
        Func<TSource, bool> predicate)
    {
        ArgumentNullException.ThrowIfNull(source);
        ArgumentNullException.ThrowIfNull(predicate);

        IEnumerable<TSource> Iterator()
        {
            foreach (var item in source)
            {
                yield return item;

                if (!predicate(item))
                    yield break;
            }
        }

        return Iterator();
    }

    /// <summary>
    /// Skip until item satisfies the predicate (inclusive)
    /// </summary>
    /// <param name="source"></param>
    /// <param name="predicate"></param>
    /// <typeparam name="TSource"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static IEnumerable<TSource> SkipUntil<TSource>(
        this IEnumerable<TSource> source,
        Func<TSource, bool> predicate)
    {
        ArgumentNullException.ThrowIfNull(source);
        ArgumentNullException.ThrowIfNull(predicate);

        IEnumerable<TSource> Iterator()
        {
            using var enumerator = source.GetEnumerator();
            do
                if (!enumerator.MoveNext())
                    yield break;
            while (!predicate(enumerator.Current));

            while (enumerator.MoveNext())
                yield return enumerator.Current;
        }

        return Iterator();
    }
}
