namespace CSharpPlus;

public static partial class EnumerablePlus
{
    /// <summary>
    /// Perform scan aggregation
    /// </summary>
    /// <param name="source"></param>
    /// <param name="mapFunction"></param>
    /// <typeparam name="TSource"></typeparam>
    /// <returns></returns>
    public static IEnumerable<TSource> Scan<TSource>(
        this IEnumerable<TSource> source,
        Func<TSource, TSource, TSource> mapFunction) =>
        ScanOperator<TSource, TSource>(
            source,
            mapFunction,
            e => e.MoveNext() ? e.Current : default);


    /// <summary>
    /// Perform scan aggregation
    /// </summary>
    /// <param name="source"></param>
    /// <param name="initialState"></param>
    /// <param name="mapFunction"></param>
    /// <typeparam name="TSource"></typeparam>
    /// <typeparam name="TState"></typeparam>
    /// <returns></returns>
    public static IEnumerable<TState> Scan<TSource, TState>(
        this IEnumerable<TSource> source,
        TState initialState,
        Func<TState, TSource, TState> mapFunction) =>
        ScanOperator(source, mapFunction, _ => initialState);

    static IEnumerable<TState> ScanOperator<TSource, TState>(
        IEnumerable<TSource> source,
        Func<TState, TSource, TState> mapFunction,
        Func<IEnumerator<TSource>, TState?> initFunc)
    {
        ArgumentNullException.ThrowIfNull(source);
        ArgumentNullException.ThrowIfNull(mapFunction);

        return Iterator();

        IEnumerable<TState> Iterator()
        {
            using var enumerator = source.GetEnumerator();

            if (initFunc(enumerator) is not { } aggregate)
                yield break;

            yield return aggregate;
            while (enumerator.MoveNext())
            {
                aggregate = mapFunction(aggregate, enumerator.Current);
                yield return aggregate;
            }
        }
    }

    /// <summary>
    /// Perform scan aggregation by key
    /// </summary>
    public static IEnumerable<(TKey, TState)> ScanBy<TSource, TKey, TState>(
        this IEnumerable<TSource> source,
        Func<TSource, TKey> keySelector,
        Func<TKey, TState> stateSelector,
        Func<TState, TKey, TSource, TState> accumulator,
        IEqualityComparer<TKey>? comparer = null) where TKey : notnull
    {
        ArgumentNullException.ThrowIfNull(source);
        ArgumentNullException.ThrowIfNull(keySelector);
        ArgumentNullException.ThrowIfNull(stateSelector);
        ArgumentNullException.ThrowIfNull(accumulator);

        IEnumerable<(TKey, TState)> Iterator()
        {
            comparer ??= EqualityComparer<TKey>.Default;

            var dict = new Dictionary<TKey, TState>(comparer);
            foreach (var item in source)
            {
                var key = keySelector(item);
                var state = dict.TryGetValue(key, out var s) ? s : stateSelector(key);
                state = accumulator(state, key, item);
                dict[key] = state;
                yield return (key, state);
            }
        }

        return Iterator();
    }
}
