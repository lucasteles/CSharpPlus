using System;
using System.Threading.Tasks;

#pragma warning disable CS1591
#pragma warning disable S4136
#pragma warning disable S3218

/// <summary>
/// Tuple of Tasks Extensions
/// </summary>
public static class TaskTupleExtensions
{
    public static Task<T1> WhenAll<T1>(this ValueTuple<Task<T1>> tasks) => tasks.Item1;

    public static async Task<(T1, T2)> WhenAll<T1, T2>(this (Task<T1>, Task<T2>) tasks)
    {
        var (t1, t2) = tasks;
        await Task.WhenAll(t1, t2);
        return (t1.Result, t2.Result);
    }

    public static async Task<(T1, T2, T3)> WhenAll<T1, T2, T3>(
        this (Task<T1>, Task<T2>, Task<T3>) tasks)
    {
        var (t1, t2, t3) = tasks;
        await Task.WhenAll(t1, t2, t3);
        return (t1.Result, t2.Result, t3.Result);
    }

    public static async Task<(T1, T2, T3, T4)> WhenAll<T1, T2, T3, T4>(
        this (Task<T1>, Task<T2>, Task<T3>, Task<T4>) tasks)
    {
        var (t1, t2, t3, t4) = tasks;
        await Task.WhenAll(t1, t2, t3, t4);
        return (t1.Result, t2.Result, t3.Result, t4.Result);
    }

    public static async Task<(T1, T2, T3, T4, T5)> WhenAll<T1, T2, T3, T4, T5>(
        this (Task<T1>, Task<T2>, Task<T3>, Task<T4>, Task<T5>) tasks)
    {
        var (t1, t2, t3, t4, t5) = tasks;
        await Task.WhenAll(t1, t2, t3, t4, t5);
        return (t1.Result, t2.Result, t3.Result, t4.Result, t5.Result);
    }

    public static async Task<(T1, T2, T3, T4, T5, T6)> WhenAll<T1, T2, T3, T4, T5, T6>(
        this (Task<T1>, Task<T2>, Task<T3>, Task<T4>, Task<T5>, Task<T6>) tasks)
    {
        var (t1, t2, t3, t4, t5, t6) = tasks;
        await Task.WhenAll(t1, t2, t3, t4, t5, t6);
        return (t1.Result, t2.Result, t3.Result, t4.Result, t5.Result, t6.Result);
    }

    public static async Task<(T1, T2, T3, T4, T5, T6, T7)> WhenAll<T1, T2, T3, T4, T5, T6, T7>(
        this (Task<T1>, Task<T2>, Task<T3>, Task<T4>, Task<T5>, Task<T6>, Task<T7>) tasks)
    {
        var (t1, t2, t3, t4, t5, t6, t7) = tasks;
        await Task.WhenAll(t1, t2, t3, t4, t5, t6, t7);
        return (t1.Result, t2.Result, t3.Result, t4.Result, t5.Result, t6.Result, t7.Result);
    }

    public static async Task<(T1, T2, T3, T4, T5, T6, T7, T8)> WhenAll<T1, T2, T3, T4, T5, T6, T7, T8>(
        this (Task<T1>, Task<T2>, Task<T3>, Task<T4>, Task<T5>, Task<T6>, Task<T7>, Task<T8>) tasks)
    {
        var (t1, t2, t3, t4, t5, t6, t7, t8) = tasks;
        await Task.WhenAll(t1, t2, t3, t4, t5, t6, t7, t8);
        return (t1.Result, t2.Result, t3.Result, t4.Result, t5.Result, t6.Result, t7.Result, t8.Result);
    }

    public static async Task<(T1, T2, T3, T4, T5, T6, T7, T8, T9)> WhenAll<T1, T2, T3, T4, T5, T6, T7, T8, T9>(
        this (Task<T1>, Task<T2>, Task<T3>, Task<T4>, Task<T5>, Task<T6>, Task<T7>, Task<T8>, Task<T9>) tasks)
    {
        var (t1, t2, t3, t4, t5, t6, t7, t8, t9) = tasks;
        await Task.WhenAll(t1, t2, t3, t4, t5, t6, t7, t8, t9);
        return (t1.Result, t2.Result, t3.Result, t4.Result, t5.Result, t6.Result, t7.Result, t8.Result, t9.Result);
    }

    public static async Task<(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10)>
        WhenAll<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
            this (Task<T1>, Task<T2>, Task<T3>, Task<T4>,
                Task<T5>, Task<T6>, Task<T7>, Task<T8>, Task<T9>, Task<T10>)
                tasks)
    {
        var (t1, t2, t3, t4, t5, t6, t7, t8, t9, t10) = tasks;
        await Task.WhenAll(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10);
        return (t1.Result, t2.Result, t3.Result, t4.Result, t5.Result, t6.Result, t7.Result, t8.Result, t9.Result,
            t10.Result);
    }
}
