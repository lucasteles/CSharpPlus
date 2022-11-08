using System.Collections.Generic;

/// <summary>
/// Range extensions
/// </summary>
public static class RangeExtension
{
    /// <summary>
    /// Enumerate Range operators
    /// </summary>
    /// <param name="range"></param>
    /// <returns></returns>
    public static IEnumerator<int> GetEnumerator(this System.Range range)
    {
        var start = range.Start.Value;
        var end = range.End.Value;
        if (end > start)
            for (var i = start; i <= end; i++)
                yield return i;
        else
            for (var i = start; i >= end; i--)
                yield return i;
    }

    /// <summary>
    /// Enumerable Range
    /// </summary>
    /// <param name="range"></param>
    /// <returns></returns>
    public static IEnumerable<int> Enumerate(this System.Range range)
    {
        foreach (var n in range)
            yield return n;
    }
}
