namespace CSharpPlus;

public enum CompareResult
{
    Smaller = -1,
    Equal = 0,
    Greater = 1,
}

public static class LambdaComparison
{
    public static Comparison<TSource> Create<TSource, TKey>(
        Func<TSource, TKey> key,
        Comparer<TKey>? keyComparer = null
    )
        where TKey : IComparable<TKey> =>
        (x, y) => (keyComparer ?? Comparer<TKey>.Default).Compare(key(x), key(y));

    public static Comparison<TValue> Create<TValue>(
        Func<TValue, TValue, CompareResult> compareFunc) =>
        (x, y) => (int)compareFunc(x, y);
}

public static class LambdaComparer
{
    public static IComparer<TValue> Create<TValue>(
        Func<TValue, TValue, CompareResult> comparerFunc
    ) => Comparer<TValue>.Create((x, y) => (int)comparerFunc(x, y));

    public static IComparer<TSource> Create<TSource, TKey>(
        Func<TSource, TKey> key,
        Comparer<TKey>? keyComparer = null
    )
        where TKey : IComparable<TKey> =>
        Comparer<TSource>.Create((x, y) =>
            (keyComparer ?? Comparer<TKey>.Default).Compare(key(x), key(y)));
}
