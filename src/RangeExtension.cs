using System.Collections;

namespace CSharpPlus;

/// <summary>
/// Range extensions
/// </summary>
public static class RangeExtension
{
    /// <summary>
    /// Enumerate Range operators
    /// ^ sets the value as exclusive
    /// </summary>
    /// <param name="range"></param>
    /// <returns></returns>
    public static RangeEnumerator GetEnumerator(this Range range) => new(range);

    public struct RangeEnumerator : IEnumerator<int>
    {
        readonly bool isAscending;
        readonly int last;
        readonly int start;
        int? current;

        public RangeEnumerator(Range range)
        {
            isAscending = range.End.Value > range.Start.Value;
            last = range.End.Value;
            start = range.Start.Value;

            if (isAscending)
            {
                if (range.End.IsFromEnd) last--;
                if (range.Start.IsFromEnd) start++;
            }
            else
            {
                if (range.End.IsFromEnd) last++;
                if (range.Start.IsFromEnd) start--;
            }
        }

        public readonly int Current =>
            current
            ?? throw new InvalidOperationException("Iterator has not been initialized.");

        readonly object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            if (!current.HasValue)
            {
                current = start;
                return true;
            }

            if (isAscending)
            {
                if (Current >= last) return false;
                current++;
            }
            else
            {
                if (Current <= last) return false;
                current--;
            }

            return true;
        }

        public void Reset() => current = start;

        public readonly void Dispose()
        {
        }
    }

    /// <summary>
    /// Enumerable Range
    /// </summary>
    /// <param name="range"></param>
    /// <returns></returns>
    public static IEnumerable<int> Enumerate(this Range range)
    {
        foreach (var n in range)
            yield return n;
    }

    /// <summary>
    /// Map Enumerate int
    /// </summary>
    /// <param name="range"></param>
    /// <param name="map"></param>
    /// <typeparam name="TMap"></typeparam>
    /// <returns></returns>
    public static IEnumerable<TMap> Select<TMap>(this Range range, Func<int, TMap> map) =>
        range.Enumerate().Select(map);

    /// <summary>
    /// Int Bind Projection
    /// </summary>
    /// <param name="range"></param>
    /// <param name="projection"></param>
    /// <param name="project"></param>
    /// <typeparam name="TMap"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    public static IEnumerable<TResult> SelectMany<TMap, TResult>(
        this Range range,
        Func<int, IEnumerable<TMap>> projection,
        Func<int, TMap, TResult> project) =>
        range.Enumerate().SelectMany(projection, project);

    /// <summary>
    /// Int Bind Projection
    /// </summary>
    /// <param name="range"></param>
    /// <param name="projection"></param>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    public static IEnumerable<TResult> SelectMany<TResult>(
        this Range range,
        Func<int, IEnumerable<TResult>> projection) =>
        range.Enumerate().SelectMany(projection);

    /// <summary>
    /// Range Bind Projection
    /// </summary>
    /// <param name="range"></param>
    /// <param name="projection"></param>
    /// <param name="project"></param>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    public static IEnumerable<TResult> SelectMany<TResult>(
        this Range range,
        Func<int, Range> projection,
        Func<int, int, TResult> project)
    {
        foreach (var n1 in range)
            foreach (var n2 in projection(n1))
                yield return project(n1, n2);
    }

    /// <summary>
    /// Range Bind Projection
    /// </summary>
    /// <param name="range"></param>
    /// <param name="projection"></param>
    /// <returns></returns>
    public static IEnumerable<int> SelectMany(this Range range, Func<int, Range> projection) =>
        range.SelectMany(projection, (_, n) => n);
}
