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
}
