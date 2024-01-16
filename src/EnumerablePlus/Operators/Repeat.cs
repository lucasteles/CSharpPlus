namespace CSharpPlus;

/// <summary>
/// Enumerable Plus Extensions
/// </summary>
public static partial class EnumerablePlus
{
    /// <summary>
    /// Repeats the sequence indefinitely or a specific number of times.
    /// </summary>
    /// <param name="source"></param>
    /// <param name="times">How many times should repeat the sequence</param>
    /// <typeparam name="TSource"></typeparam>
    /// <exception cref="ArgumentNullException"></exception>
    public static IEnumerable<TSource> Repeat<TSource>(this IEnumerable<TSource> source, int times)
    {
        ArgumentNullException.ThrowIfNull(source);
        if (times < 0)
            throw new ArgumentOutOfRangeException(nameof(times), "Cant be negative");

        IEnumerable<TSource> Iterator()
        {
            if (times is 0) yield break;

            List<TSource> cache = new();
            foreach (var item in source)
            {
                cache.Add(item);
                yield return item;
            }

            for (var i = 1; i < times; i++)
                foreach (var item in cache)
                    yield return item;
        }

        return Iterator();
    }


    /// <summary>
    /// Repeats the sequence indefinitely or until cancellation is requested
    /// </summary>
    /// <param name="source"></param>
    /// <param name="cancellationToken"></param>
    /// <typeparam name="TSource"></typeparam>
    /// <exception cref="ArgumentNullException"></exception>
    public static IEnumerable<TSource> RepeatForever<TSource>(
        this IEnumerable<TSource> source,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(source);

        IEnumerable<TSource> Iterator()
        {
            List<TSource> cache = new();
            foreach (var item in source)
            {
                cache.Add(item);
                yield return item;
            }

            while (!cancellationToken.IsCancellationRequested)
                foreach (var item in cache)
                    yield return item;
        }

        return Iterator();
    }
}
