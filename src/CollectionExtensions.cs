namespace CSharpPlus;

/// <summary>
/// Collection extensions
/// </summary>
public static class CollectionExtensions
{
    /// <summary>
    /// Adds the elements of the specified collection to the end of the ICollection of T.
    /// </summary>
    public static void AddRange<T>(this ICollection<T> self, IEnumerable<T> items)
    {
        ArgumentNullException.ThrowIfNull(self);
        ArgumentNullException.ThrowIfNull(items);
        switch (self)
        {
            case List<T> list:
                list.AddRange(items);
                break;

            case HashSet<T> hashSet:
                hashSet.UnionWith(items);
                break;

            default:
                foreach (var item in items)
                    self.Add(item);
                break;
        }
    }

    /// <summary>
    /// Removes the list item at the specified index.
    /// </summary>
    public static void RemoveAt<T>(this IList<T> self, Index index)
    {
        ArgumentNullException.ThrowIfNull(self);
        var offset = index.GetOffset(self.Count);
        self.RemoveAt(offset);
    }

    /// <summary>
    /// Removes the list item at the specified range.
    /// </summary>
    public static void RemoveRange<T>(this List<T> self, Range range)
    {
        ArgumentNullException.ThrowIfNull(self);
        var (offset, length) = range.GetOffsetAndLength(self.Count);
        self.RemoveRange(offset, length);
    }
}
