using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

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
        @this.ToDictionary(x => x.Key, x => x.Value);

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

    /// <summary>
    /// Return a task waiting for each key on the dictionary
    /// </summary>
    [SuppressMessage("AsyncUsage",
        "AsyncFixer02:Long-running or blocking operations inside an async method")]
    public static async Task<IDictionary<TKey, TValue>> WhenAll<TKey, TValue>(
        this IDictionary<TKey, Task<TValue>> @this) where TKey : notnull
    {
        await Task.WhenAll(@this.Values).ConfigureAwait(false);
        return @this.ToDictionary(x => x.Key, x => x.Value.Result);
    }
}
