namespace CSharpPlus;

/// <summary>
/// Dictionary Extensions
/// </summary>
public static class DictionaryExtensions
{
    /// <summary>
    /// Create a Dictionary from a KeyValuePair collection
    /// </summary>
    public static IDictionary<TKey, TValue> ToDictionary<TKey, TValue>(
        this IEnumerable<KeyValuePair<TKey, TValue>> @this) where TKey : notnull =>
        new Dictionary<TKey, TValue>(@this);

    /// <summary>
    /// Return a new dictionary with the values for this dictionary merged with the other, replacing any duplicated key
    /// </summary>
    public static IDictionary<TKey, TValue> Merge<TKey, TValue>(
        this IEnumerable<KeyValuePair<TKey, TValue>> @this,
        IEnumerable<KeyValuePair<TKey, TValue>> other) where TKey : notnull =>
        Enumerable.Empty<IEnumerable<KeyValuePair<TKey, TValue>>>()
            .Append(@this)
            .Append(other)
            .Merge();

    /// <summary>
    /// Return a new dictionary with merged values for each Dictionary in the collection
    /// </summary>
    public static IDictionary<TKey, TValue> Merge<TKey, TValue>(
        this IEnumerable<IEnumerable<KeyValuePair<TKey, TValue>>> @this) where TKey : notnull
    {
        var result = new Dictionary<TKey, TValue>();
        foreach (var (key, value) in @this.SelectMany()) result[key] = value;
        return result;
    }
}
