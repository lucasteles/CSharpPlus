using System.Collections.Generic;
using System.Threading.Tasks;

namespace System.Linq;

/// <summary>
/// Enumerable Plus Extensions
/// </summary>
public static partial class EnumerablePlus
{
    /// <summary>
    /// Creates a task that will complete when all of the Task objects in an enumerable collection have completed.
    /// </summary>
    /// <param name="tasks"></param>
    /// <returns>
    /// A task that represents the completion of all of the supplied tasks.
    /// </returns>
    public static Task WhenAll(this IEnumerable<Task> tasks) => Task.WhenAll(tasks);

    /// <summary>
    /// Creates a task that will complete when all of the Task[TResult] objects in an enumerable collection have completed.
    /// </summary>
    /// <param name="tasks"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static async Task<IEnumerable<T>> WhenAll<T>(this IEnumerable<Task<T>> tasks) =>
        await Task.WhenAll(tasks);

    /// <summary>
    /// Creates a task that will complete when any of the supplied tasks have completed.
    /// </summary>
    /// <param name="tasks"></param>
    /// <returns>
    /// A task that represents the completion of one of the supplied tasks. The return task's Result is the task that completed.
    /// </returns>
    public static Task WhenAny(this IEnumerable<Task> tasks) => Task.WhenAny(tasks);

    /// <summary>
    /// Creates a task that will complete when any of the supplied tasks have completed.
    /// </summary>
    /// <param name="tasks">The tasks to wait on for completion</param>
    /// <typeparam name="T"></typeparam>
    /// <returns>
    /// A task that represents the completion of one of the supplied tasks. The return task's Result is the task that completed.
    /// </returns>
    public static async Task<T> WhenAny<T>(this IEnumerable<Task<T>> tasks) =>
        await await Task.WhenAny(tasks);
}
