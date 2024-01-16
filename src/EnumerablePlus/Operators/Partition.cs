namespace CSharpPlus;

public static partial class EnumerablePlus
{
    /// <summary>
    /// Splits an enumerable in two using a predicate.
    /// </summary>
    /// <returns>
    /// A 2-tuple of enumerable elements for true and false predicate
    /// </returns>
    public static (IEnumerable<T> True, IEnumerable<T> False)
        Partition<T>(this IEnumerable<T> source, Func<T, bool> predicate)
    {
        ArgumentNullException.ThrowIfNull(source);
        ArgumentNullException.ThrowIfNull(predicate);

        var trueValues = Enumerable.Empty<T>();
        var falseValues = Enumerable.Empty<T>();

        foreach (var group in source.GroupBy(predicate))
        {
            switch (group.Key)
            {
                case true:
                    trueValues = group;
                    break;
                case false:
                    falseValues = group;
                    break;
            }
        }

        return (trueValues, falseValues);
    }
}
