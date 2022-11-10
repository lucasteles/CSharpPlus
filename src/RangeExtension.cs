using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

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
    public static IEnumerator<int> GetEnumerator(this Range range)
    {
        static int IndexToInt(Index index) =>
            index.Value * (index.IsFromEnd ? -1 : 1);

        var start = IndexToInt(range.Start);
        var end = IndexToInt(range.End);

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


    /// <summary>
    /// Creates an array from a Range
    /// </summary>
    /// <returns></returns>
    public static int[] ToArray(
        this Range range) =>
        range.Enumerate().ToArray();

    /// <summary>
    /// Creates an List from a Range
    /// </summary>
    /// <returns></returns>
    public static List<int> ToList(
        this Range range) =>
        range.Enumerate().ToList();


    /// <summary>
    /// Creates an array from a Range
    /// </summary>
    /// <returns></returns>
    public static IReadOnlyCollection<int> ToReadOnly(
        this Range range) =>
        range.Enumerate().ToImmutableArray();
}
