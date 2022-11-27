using System.Collections.Generic;

namespace CSharpPlus;

/// <summary>
/// Collection extensions
/// </summary>
public static class CollectionExtensions
{
    /// <summary>
    /// Adds the elements of the specified collection to the end of the IList of T.
    /// </summary>
    public static void AddRange<T>(this IList<T> self, IEnumerable<T> items)
    {
        foreach (var item in items)
            self.Add(item);
    }

    /// <summary>
    /// Adds the elements of the specified collection to the end of the ICollection of T.
    /// </summary>
    public static void AddRange<T>(this ICollection<T> self, IEnumerable<T> items)
    {
        foreach (var item in items)
            self.Add(item);
    }
}
