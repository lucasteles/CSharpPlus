using CSharpPlus;

/// <summary>
/// Enumerable Plus Extensions
/// </summary>
public static class ArrayExtensions
{
    /// <summary>
    ///  Filters an array of values based on a predicate.
    /// </summary>
    public static TSource[]
        FindAll<TSource>(this TSource[] @this, Func<TSource, bool> predicate) =>
        Array.FindAll(@this, new Predicate<TSource>(predicate));

    /// <summary>
    ///  Determines whether the specified array contains elements that match the conditions defined by the specified predicate.
    /// </summary>
    public static bool
        Exist<TSource>(this TSource[] @this, Func<TSource, bool> predicate) =>
        Array.Exists(@this, new Predicate<TSource>(predicate));

    /// <summary>
    ///  Searches for an element that matches the conditions defined by the specified predicate, and returns the first occurrence within the entire Array.
    /// </summary>
    public static TSource?
        Find<TSource>(this TSource[] @this, Func<TSource, bool> predicate) =>
        Array.Find(@this, new Predicate<TSource>(predicate));

    /// <summary>
    ///  Searches for an element that matches the conditions defined by the specified predicate, and returns the last occurrence within the entire Array.
    /// </summary>
    public static TSource?
        FindLast<TSource>(this TSource[] @this, Func<TSource, bool> predicate) =>
        Array.FindLast(@this, new Predicate<TSource>(predicate));

    /// <summary>
    ///  Searches for an element that matches the conditions defined by the specified predicate, and returns the zero-based index of the first occurrence within the entire Array.
    /// </summary>
    public static int
        FindIndex<TSource>(this TSource[] @this, Func<TSource, bool> predicate) =>
        Array.FindIndex(@this, new Predicate<TSource>(predicate));

    /// <summary>
    ///  Searches for an element that matches the conditions defined by the specified predicate, and returns the zero-based index of the last occurrence within the entire Array.
    /// </summary>
    public static int
        FindLastIndex<TSource>(this TSource[] @this, Func<TSource, bool> predicate) =>
        Array.FindLastIndex(@this, new Predicate<TSource>(predicate));

    /// <summary>
    ///  Sorts the elements of an array in ascending order according to a key.
    /// </summary>
    public static TSource[]
        SortBy<TSource, TKey>(this TSource[] @this, Func<TSource, TKey> selector)
        where TKey : IComparable<TKey>
    {
        var copy = new TSource[@this.Length];
        Array.Copy(@this, copy, @this.Length);
        Array.Sort(copy, LambdaComparison.Create(selector));
        return copy;
    }

    /// <summary>
    ///  Sorts the elements of an array in ascending order.
    /// </summary>
    public static TSource[] Sort<TSource>(this TSource[] @this)
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
        ConvertAll<TSource, TResult>(this TSource[] @this, Func<TSource, TResult> selector) =>
        Array.ConvertAll(@this, new Converter<TSource, TResult>(selector));
}
