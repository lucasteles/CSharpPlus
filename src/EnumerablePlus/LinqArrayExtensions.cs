/// <summary>
/// Enumerable Plus Extensions
/// </summary>
public static class ArrayPlus
{
    /// <summary>
    ///  Filters an array of values based on a predicate.
    /// </summary>
    public static TSource[]
        WhereArray<TSource>(this TSource[] @this, Func<TSource, bool> predicate) =>
        Array.FindAll(@this, new Predicate<TSource>(predicate));

    /// <summary>
    ///  Sorts the elements of an array in ascending order according to a key.
    /// </summary>
    public static TSource[]
        OrderByArray<TSource, TKey>(this TSource[] @this, Func<TSource, TKey> selector)
        where TKey : IComparable<TKey>
    {
        var copy = new TSource[@this.Length];
        Array.Copy(@this, copy, @this.Length);
        Array.Sort(copy, KeyComparison(selector));
        return copy;
    }

    /// <summary>
    ///  Sorts the elements of an array in ascending order.
    /// </summary>
    public static TSource[] OrderArray<TSource>(this TSource[] @this)
    {
        var copy = new TSource[@this.Length];
        Array.Copy(@this, copy, @this.Length);
        Array.Sort(copy);
        return copy;
    }

    /// <summary>
    ///  Sorts the elements of an array in ascending order.
    /// </summary>
    public static TSource[] ConcatArray<TSource>(this TSource[] @this, TSource[] other)
    {
        var copy = new TSource[@this.Length + other.Length];
        Array.Copy(@this, copy, @this.Length);
        Array.Copy(other, 0, copy, @this.Length, other.Length);
        return copy;
    }


    /// <summary>
    ///  Projects each element of an array into a new form.
    /// </summary>
    public static TResult[]
        SelectArray<TSource, TResult>(this TSource[] @this, Func<TSource, TResult> selector) =>
        Array.ConvertAll(@this, new Converter<TSource, TResult>(selector));

    static Comparison<TSource> KeyComparison<TSource, TKey>(Func<TSource, TKey> key)
        where TKey : IComparable<TKey> =>
        (x, y) => Comparer<TKey>.Default.Compare(key(x), key(y));
}
