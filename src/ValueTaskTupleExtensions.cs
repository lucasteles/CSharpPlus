#pragma warning disable CS1591
#pragma warning disable CA2012
#pragma warning disable S4136
#pragma warning disable S3218
#pragma warning disable S5034

using System.Runtime.CompilerServices;
using CSharpPlus;


/// <summary>
/// Tuple of Tasks Extensions
/// </summary>
public static class ValueTaskTupleExtensions
{
    #region Tuple 1

    public static ValueTaskAwaiter<T1> GetAwaiter<T1>(this ValueTuple<ValueTask<T1>> tasks) =>
        tasks.Item1.GetAwaiter();

    public static ConfiguredValueTaskAwaitable<T1> ConfigureAwait<T1>(
        this ValueTuple<ValueTask<T1>> tasks, bool continueOnCapturedContext) =>
        tasks.Item1.ConfigureAwait(continueOnCapturedContext);

    #endregion

    #region Tuple 2

    public static TupleValueTaskAwaiter<T1, T2> GetAwaiter<T1, T2>(this (ValueTask<T1>, ValueTask<T2>) tasks) =>
        new(tasks);

    public readonly struct TupleValueTaskAwaiter<T1, T2>((ValueTask<T1>, ValueTask<T2>) tasks) : INotifyCompletion
    {
        readonly ValueTaskAwaiter<(T1, T2)> whenAllAwaiter =
            ValueTaskPlus.WhenEach(in tasks).GetAwaiter();

        public bool IsCompleted => whenAllAwaiter.IsCompleted;
        public void OnCompleted(Action continuation) => whenAllAwaiter.OnCompleted(continuation);

        public (T1, T2) GetResult() => whenAllAwaiter.GetResult();
    }

    public static TupleConfiguredValueTaskAwaitable<T1, T2> ConfigureAwait<T1, T2>(
        this (ValueTask<T1>, ValueTask<T2>) tasks,
        bool continueOnCapturedContext) =>
        new(tasks, continueOnCapturedContext);

    public readonly struct TupleConfiguredValueTaskAwaitable<T1, T2>(
        (ValueTask<T1>, ValueTask<T2>) tasks,
        bool continueOnCapturedContext)
    {
        public Awaiter GetAwaiter() => new(tasks, continueOnCapturedContext);

        public readonly struct Awaiter((ValueTask<T1>, ValueTask<T2>) tasks, bool continueOnCapturedContext)
            : INotifyCompletion
        {
            readonly ConfiguredValueTaskAwaitable<(T1, T2)>.ConfiguredValueTaskAwaiter whenAllAwaiter =
                ValueTaskPlus.WhenEach(in tasks)
                    .ConfigureAwait(continueOnCapturedContext)
                    .GetAwaiter();

            public bool IsCompleted => whenAllAwaiter.IsCompleted;
            public void OnCompleted(Action continuation) => whenAllAwaiter.OnCompleted(continuation);

            public (T1, T2) GetResult() => whenAllAwaiter.GetResult();
        }
    }

    #endregion

    #region Tuple 3

    public static TupleValueTaskAwaiter<T1, T2, T3> GetAwaiter<T1, T2, T3>(
        this (ValueTask<T1>, ValueTask<T2>, ValueTask<T3>) tasks) =>
        new(tasks);

    public readonly struct TupleValueTaskAwaiter<T1, T2, T3>(
        (ValueTask<T1>, ValueTask<T2>, ValueTask<T3>) tasks)
        : INotifyCompletion
    {
        readonly ValueTaskAwaiter<(T1, T2, T3)> whenAllAwaiter =
            ValueTaskPlus.WhenEach(in tasks).GetAwaiter();

        public bool IsCompleted => whenAllAwaiter.IsCompleted;
        public void OnCompleted(Action continuation) => whenAllAwaiter.OnCompleted(continuation);

        public (T1, T2, T3) GetResult() => whenAllAwaiter.GetResult();
    }

    public static TupleConfiguredValueTaskAwaitable<T1, T2, T3> ConfigureAwait<T1, T2, T3>(
        this (ValueTask<T1>, ValueTask<T2>, ValueTask<T3>) tasks, bool continueOnCapturedContext) =>
        new(tasks, continueOnCapturedContext);

    public readonly struct TupleConfiguredValueTaskAwaitable<T1, T2, T3>(
        (ValueTask<T1>, ValueTask<T2>, ValueTask<T3>) tasks,
        bool continueOnCapturedContext)
    {
        public Awaiter GetAwaiter() => new(tasks, continueOnCapturedContext);

        public readonly struct Awaiter(
            (ValueTask<T1>, ValueTask<T2>, ValueTask<T3>) tasks,
            bool continueOnCapturedContext)
            : INotifyCompletion
        {
            readonly ConfiguredValueTaskAwaitable<(T1, T2, T3)>.ConfiguredValueTaskAwaiter whenAllAwaiter =
                ValueTaskPlus
                    .WhenEach(in tasks)
                    .ConfigureAwait(continueOnCapturedContext)
                    .GetAwaiter();

            public bool IsCompleted => whenAllAwaiter.IsCompleted;
            public void OnCompleted(Action continuation) => whenAllAwaiter.OnCompleted(continuation);

            public (T1, T2, T3) GetResult() => whenAllAwaiter.GetResult();
        }
    }

    #endregion

    #region Tuple 4

    public static TupleValueTaskAwaiter<T1, T2, T3, T4> GetAwaiter<T1, T2, T3, T4>(
        this (ValueTask<T1>, ValueTask<T2>, ValueTask<T3>, ValueTask<T4>) tasks) =>
        new(tasks);

    public readonly struct TupleValueTaskAwaiter<T1, T2, T3, T4>(
        (ValueTask<T1>, ValueTask<T2>, ValueTask<T3>, ValueTask<T4>) tasks)
        : INotifyCompletion
    {
        readonly ValueTaskAwaiter<(T1, T2, T3, T4)> whenAllAwaiter =
            ValueTaskPlus.WhenEach(in tasks).GetAwaiter();

        public bool IsCompleted => whenAllAwaiter.IsCompleted;
        public void OnCompleted(Action continuation) => whenAllAwaiter.OnCompleted(continuation);

        public (T1, T2, T3, T4) GetResult() => whenAllAwaiter.GetResult();
    }

    public static TupleConfiguredValueTaskAwaitable<T1, T2, T3, T4> ConfigureAwait<T1, T2, T3, T4>(
        this (ValueTask<T1>, ValueTask<T2>, ValueTask<T3>, ValueTask<T4>) tasks, bool continueOnCapturedContext) =>
        new(tasks, continueOnCapturedContext);

    public readonly struct TupleConfiguredValueTaskAwaitable<T1, T2, T3, T4>(
        (ValueTask<T1>, ValueTask<T2>, ValueTask<T3>, ValueTask<T4>) tasks,
        bool continueOnCapturedContext)
    {
        public Awaiter GetAwaiter() => new(tasks, continueOnCapturedContext);

        public readonly struct Awaiter(
            (ValueTask<T1>, ValueTask<T2>, ValueTask<T3>, ValueTask<T4>) tasks,
            bool continueOnCapturedContext)
            : INotifyCompletion
        {
            readonly ConfiguredValueTaskAwaitable<(T1, T2, T3, T4)>.ConfiguredValueTaskAwaiter whenAllAwaiter =
                ValueTaskPlus
                    .WhenEach(in tasks)
                    .ConfigureAwait(continueOnCapturedContext)
                    .GetAwaiter();

            public bool IsCompleted => whenAllAwaiter.IsCompleted;
            public void OnCompleted(Action continuation) => whenAllAwaiter.OnCompleted(continuation);

            public (T1, T2, T3, T4) GetResult() => whenAllAwaiter.GetResult();
        }
    }

    #endregion


    #region Tuple 5

    public static TupleValueTaskAwaiter<T1, T2, T3, T4, T5> GetAwaiter<T1, T2, T3, T4, T5>(
        this (ValueTask<T1>, ValueTask<T2>, ValueTask<T3>, ValueTask<T4>, ValueTask<T5>) tasks) => new(tasks);

    public readonly struct TupleValueTaskAwaiter<T1, T2, T3, T4, T5>(
        (ValueTask<T1>, ValueTask<T2>, ValueTask<T3>, ValueTask<T4>, ValueTask<T5>) tasks) : INotifyCompletion
    {
        readonly ValueTaskAwaiter<(T1, T2, T3, T4, T5)> whenAllAwaiter =
            ValueTaskPlus.WhenEach(in tasks).GetAwaiter();

        public bool IsCompleted => whenAllAwaiter.IsCompleted;
        public void OnCompleted(Action continuation) => whenAllAwaiter.OnCompleted(continuation);

        public (T1, T2, T3, T4, T5) GetResult() => whenAllAwaiter.GetResult();
    }

    public static TupleConfiguredValueTaskAwaitable<T1, T2, T3, T4, T5> ConfigureAwait<T1, T2, T3, T4, T5>(
        this (ValueTask<T1>, ValueTask<T2>, ValueTask<T3>, ValueTask<T4>, ValueTask<T5>) tasks,
        bool continueOnCapturedContext) =>
        new(tasks, continueOnCapturedContext);

    public readonly struct TupleConfiguredValueTaskAwaitable<T1, T2, T3, T4, T5>(
        (ValueTask<T1>, ValueTask<T2>, ValueTask<T3>, ValueTask<T4>, ValueTask<T5>) tasks,
        bool continueOnCapturedContext)
    {
        public Awaiter GetAwaiter() => new(tasks, continueOnCapturedContext);

        public readonly struct Awaiter(
            (ValueTask<T1>, ValueTask<T2>, ValueTask<T3>, ValueTask<T4>, ValueTask<T5>) tasks,
            bool continueOnCapturedContext)
            : INotifyCompletion
        {
            readonly ConfiguredValueTaskAwaitable<(T1, T2, T3, T4, T5)>.ConfiguredValueTaskAwaiter whenAllAwaiter =
                ValueTaskPlus
                    .WhenEach(in tasks)
                    .ConfigureAwait(continueOnCapturedContext)
                    .GetAwaiter();

            public bool IsCompleted => whenAllAwaiter.IsCompleted;
            public void OnCompleted(Action continuation) => whenAllAwaiter.OnCompleted(continuation);

            public (T1, T2, T3, T4, T5) GetResult() => whenAllAwaiter.GetResult();
        }
    }

    #endregion

    #region Tuple 6

    public static TupleValueTaskAwaiter<T1, T2, T3, T4, T5, T6> GetAwaiter<T1, T2, T3, T4, T5, T6>(
        this (ValueTask<T1>, ValueTask<T2>, ValueTask<T3>, ValueTask<T4>, ValueTask<T5>, ValueTask<T6>) tasks) =>
        new(tasks);

    public readonly struct TupleValueTaskAwaiter<T1, T2, T3, T4, T5, T6>(
        (ValueTask<T1>, ValueTask<T2>, ValueTask<T3>, ValueTask<T4>, ValueTask<T5>, ValueTask<T6>) tasks)
        : INotifyCompletion
    {
        readonly ValueTaskAwaiter<(T1, T2, T3, T4, T5, T6)> whenAllAwaiter = ValueTaskPlus
            .WhenEach(in tasks)
            .GetAwaiter();

        public bool IsCompleted => whenAllAwaiter.IsCompleted;
        public void OnCompleted(Action continuation) => whenAllAwaiter.OnCompleted(continuation);

        public (T1, T2, T3, T4, T5, T6) GetResult() => whenAllAwaiter.GetResult();
    }

    public static TupleConfiguredValueTaskAwaitable<T1, T2, T3, T4, T5, T6> ConfigureAwait<T1, T2, T3, T4, T5, T6>(
        this (ValueTask<T1>, ValueTask<T2>, ValueTask<T3>, ValueTask<T4>, ValueTask<T5>, ValueTask<T6>) tasks,
        bool continueOnCapturedContext) =>
        new(tasks, continueOnCapturedContext);

    public readonly struct TupleConfiguredValueTaskAwaitable<T1, T2, T3, T4, T5, T6>(
        (ValueTask<T1>, ValueTask<T2>, ValueTask<T3>, ValueTask<T4>, ValueTask<T5>, ValueTask<T6>) tasks,
        bool continueOnCapturedContext)
    {
        public Awaiter GetAwaiter() => new(tasks, continueOnCapturedContext);

        public readonly struct Awaiter(
            (ValueTask<T1>, ValueTask<T2>, ValueTask<T3>, ValueTask<T4>, ValueTask<T5>, ValueTask<T6>) tasks,
            bool continueOnCapturedContext)
            : INotifyCompletion
        {
            readonly ConfiguredValueTaskAwaitable<(T1, T2, T3, T4, T5, T6)>.ConfiguredValueTaskAwaiter whenAllAwaiter =
                ValueTaskPlus
                    .WhenEach(in tasks).ConfigureAwait(continueOnCapturedContext)
                    .GetAwaiter();

            public bool IsCompleted => whenAllAwaiter.IsCompleted;
            public void OnCompleted(Action continuation) => whenAllAwaiter.OnCompleted(continuation);

            public (T1, T2, T3, T4, T5, T6) GetResult() => whenAllAwaiter.GetResult();
        }
    }

    #endregion

    #region Tuple 7

    public static TupleValueTaskAwaiter<T1, T2, T3, T4, T5, T6, T7> GetAwaiter<T1, T2, T3, T4, T5, T6, T7>(
        this (ValueTask<T1>, ValueTask<T2>, ValueTask<T3>, ValueTask<T4>, ValueTask<T5>, ValueTask<T6>, ValueTask<T7>)
            tasks) => new(tasks);

    public readonly struct TupleValueTaskAwaiter<T1, T2, T3, T4, T5, T6, T7>(
        (ValueTask<T1>, ValueTask<T2>, ValueTask<T3>, ValueTask<T4>, ValueTask<T5>, ValueTask<T6>, ValueTask<T7>) tasks)
        : INotifyCompletion
    {
        readonly ValueTaskAwaiter<(T1, T2, T3, T4, T5, T6, T7)> whenAllAwaiter =
            ValueTaskPlus.WhenEach(in tasks).GetAwaiter();

        public bool IsCompleted => whenAllAwaiter.IsCompleted;
        public void OnCompleted(Action continuation) => whenAllAwaiter.OnCompleted(continuation);

        public (T1, T2, T3, T4, T5, T6, T7) GetResult() => whenAllAwaiter.GetResult();
    }

    public static TupleConfiguredValueTaskAwaitable<T1, T2, T3, T4, T5, T6, T7> ConfigureAwait<T1, T2, T3, T4, T5, T6,
        T7>(
        this (ValueTask<T1>, ValueTask<T2>, ValueTask<T3>, ValueTask<T4>, ValueTask<T5>, ValueTask<T6>, ValueTask<T7>)
            tasks,
        bool continueOnCapturedContext) =>
        new(tasks, continueOnCapturedContext);

    public readonly struct TupleConfiguredValueTaskAwaitable<T1, T2, T3, T4, T5, T6, T7>(
        (ValueTask<T1>, ValueTask<T2>, ValueTask<T3>, ValueTask<T4>, ValueTask<T5>, ValueTask<T6>, ValueTask<T7>) tasks,
        bool continueOnCapturedContext)
    {
        public Awaiter GetAwaiter() => new(tasks, continueOnCapturedContext);

        public readonly struct Awaiter(
            (ValueTask<T1>, ValueTask<T2>, ValueTask<T3>, ValueTask<T4>, ValueTask<T5>, ValueTask<T6>, ValueTask<T7>)
                tasks,
            bool continueOnCapturedContext)
            : INotifyCompletion
        {
            readonly ConfiguredValueTaskAwaitable<(T1, T2, T3, T4, T5, T6, T7)>.ConfiguredValueTaskAwaiter
                whenAllAwaiter = ValueTaskPlus
                    .WhenEach(in tasks).ConfigureAwait(continueOnCapturedContext)
                    .GetAwaiter();

            public bool IsCompleted => whenAllAwaiter.IsCompleted;
            public void OnCompleted(Action continuation) => whenAllAwaiter.OnCompleted(continuation);

            public (T1, T2, T3, T4, T5, T6, T7) GetResult() => whenAllAwaiter.GetResult();
        }
    }

    #endregion

    #region Tuple 8

    public static TupleValueTaskAwaiter<T1, T2, T3, T4, T5, T6, T7, T8> GetAwaiter<T1, T2, T3, T4, T5, T6, T7,
        T8>(
        this (ValueTask<T1>, ValueTask<T2>, ValueTask<T3>, ValueTask<T4>, ValueTask<T5>, ValueTask<T6>, ValueTask<T7>,
            ValueTask<T8>) tasks) => new(tasks);

    public readonly struct TupleValueTaskAwaiter<T1, T2, T3, T4, T5, T6, T7, T8>(
        (ValueTask<T1>, ValueTask<T2>, ValueTask<T3>, ValueTask<T4>, ValueTask<T5>, ValueTask<T6>, ValueTask<T7>,
            ValueTask<T8>) tasks)
        : INotifyCompletion
    {
        readonly ValueTaskAwaiter<(T1, T2, T3, T4, T5, T6, T7, T8)> whenAllAwaiter =
            ValueTaskPlus.WhenEach(in tasks).GetAwaiter();

        public bool IsCompleted => whenAllAwaiter.IsCompleted;
        public void OnCompleted(Action continuation) => whenAllAwaiter.OnCompleted(continuation);

        public (T1, T2, T3, T4, T5, T6, T7, T8) GetResult() => whenAllAwaiter.GetResult();
    }

    public static TupleConfiguredValueTaskAwaitable<T1, T2, T3, T4, T5, T6, T7, T8>
        ConfigureAwait<T1, T2, T3, T4, T5, T6, T7, T8>(
            this (ValueTask<T1>, ValueTask<T2>, ValueTask<T3>, ValueTask<T4>, ValueTask<T5>, ValueTask<T6>,
                ValueTask<T7>, ValueTask<T8>) tasks,
            bool continueOnCapturedContext) =>
        new(tasks, continueOnCapturedContext);

    public readonly struct TupleConfiguredValueTaskAwaitable<T1, T2, T3, T4, T5, T6, T7, T8>(
        (ValueTask<T1>, ValueTask<T2>, ValueTask<T3>, ValueTask<T4>, ValueTask<T5>, ValueTask<T6>, ValueTask<T7>,
            ValueTask<T8>) tasks,
        bool continueOnCapturedContext)
    {
        public Awaiter GetAwaiter() => new(tasks, continueOnCapturedContext);

        public readonly struct Awaiter(
            (ValueTask<T1>, ValueTask<T2>, ValueTask<T3>, ValueTask<T4>, ValueTask<T5>, ValueTask<T6>, ValueTask<T7>,
                ValueTask<T8>) tasks,
            bool continueOnCapturedContext)
            : INotifyCompletion
        {
            readonly ConfiguredValueTaskAwaitable<(T1, T2, T3, T4, T5, T6, T7, T8)>.ConfiguredValueTaskAwaiter
                whenAllAwaiter = ValueTaskPlus
                    .WhenEach(in tasks).ConfigureAwait(continueOnCapturedContext)
                    .GetAwaiter();

            public bool IsCompleted => whenAllAwaiter.IsCompleted;
            public void OnCompleted(Action continuation) => whenAllAwaiter.OnCompleted(continuation);

            public (T1, T2, T3, T4, T5, T6, T7, T8) GetResult() => whenAllAwaiter.GetResult();
        }
    }

    #endregion

    #region Tuple 9

    public static TupleValueTaskAwaiter<T1, T2, T3, T4, T5, T6, T7, T8, T9> GetAwaiter<T1, T2, T3, T4, T5, T6,
        T7,
        T8, T9>(
        this (ValueTask<T1>, ValueTask<T2>, ValueTask<T3>, ValueTask<T4>, ValueTask<T5>, ValueTask<T6>, ValueTask<T7>,
            ValueTask<T8>, ValueTask<T9>) tasks) =>
        new(tasks);

    public readonly struct TupleValueTaskAwaiter<T1, T2, T3, T4, T5, T6, T7, T8, T9>(
        (ValueTask<T1>, ValueTask<T2>, ValueTask<T3>, ValueTask<T4>, ValueTask<T5>, ValueTask<T6>, ValueTask<T7>,
            ValueTask<T8>, ValueTask<T9>) tasks)
        : INotifyCompletion
    {
        readonly ValueTaskAwaiter<(T1, T2, T3, T4, T5, T6, T7, T8, T9)> whenAllAwaiter =
            ValueTaskPlus.WhenEach(in tasks).GetAwaiter();

        public bool IsCompleted => whenAllAwaiter.IsCompleted;
        public void OnCompleted(Action continuation) => whenAllAwaiter.OnCompleted(continuation);

        public (T1, T2, T3, T4, T5, T6, T7, T8, T9) GetResult() => whenAllAwaiter.GetResult();
    }

    public static TupleConfiguredValueTaskAwaitable<T1, T2, T3, T4, T5, T6, T7, T8, T9>
        ConfigureAwait<T1, T2, T3, T4, T5, T6, T7, T8, T9>(
            this (ValueTask<T1>, ValueTask<T2>, ValueTask<T3>, ValueTask<T4>, ValueTask<T5>, ValueTask<T6>,
                ValueTask<T7>, ValueTask<T8>, ValueTask<T9>) tasks,
            bool continueOnCapturedContext) =>
        new(tasks, continueOnCapturedContext);

    public readonly struct TupleConfiguredValueTaskAwaitable<T1, T2, T3, T4, T5, T6, T7, T8, T9>(
        (ValueTask<T1>, ValueTask<T2>, ValueTask<T3>, ValueTask<T4>, ValueTask<T5>, ValueTask<T6>, ValueTask<T7>,
            ValueTask<T8>, ValueTask<T9>) tasks,
        bool continueOnCapturedContext)
    {
        public Awaiter GetAwaiter() => new(tasks, continueOnCapturedContext);

        public readonly struct Awaiter(
            (ValueTask<T1>, ValueTask<T2>, ValueTask<T3>, ValueTask<T4>, ValueTask<T5>, ValueTask<T6>, ValueTask<T7>,
                ValueTask<T8>, ValueTask<T9>) tasks,
            bool continueOnCapturedContext)
            : INotifyCompletion
        {
            readonly ConfiguredValueTaskAwaitable<(T1, T2, T3, T4, T5, T6, T7, T8, T9)>.ConfiguredValueTaskAwaiter
                whenAllAwaiter = ValueTaskPlus
                    .WhenEach(in tasks).ConfigureAwait(continueOnCapturedContext)
                    .GetAwaiter();

            public bool IsCompleted => whenAllAwaiter.IsCompleted;
            public void OnCompleted(Action continuation) => whenAllAwaiter.OnCompleted(continuation);

            public (T1, T2, T3, T4, T5, T6, T7, T8, T9) GetResult() => whenAllAwaiter.GetResult();
        }
    }

    #endregion

    #region Tuple 10

    public static TupleValueTaskAwaiter<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>
        GetAwaiter<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
            this (ValueTask<T1>, ValueTask<T2>, ValueTask<T3>, ValueTask<T4>, ValueTask<T5>, ValueTask<T6>,
                ValueTask<T7>, ValueTask<T8>, ValueTask<T9>, ValueTask<T10>)
                tasks) =>
        new(tasks);

    public readonly struct TupleValueTaskAwaiter<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
        (ValueTask<T1>, ValueTask<T2>, ValueTask<T3>, ValueTask<T4>, ValueTask<T5>, ValueTask<T6>, ValueTask<T7>,
            ValueTask<T8>, ValueTask<T9>, ValueTask<T10>) tasks)
        : INotifyCompletion
    {
        readonly ValueTaskAwaiter<(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10)> whenAllAwaiter =
            ValueTaskPlus.WhenEach(in tasks).GetAwaiter();

        public bool IsCompleted => whenAllAwaiter.IsCompleted;
        public void OnCompleted(Action continuation) => whenAllAwaiter.OnCompleted(continuation);

        public (T1, T2, T3, T4, T5, T6, T7, T8, T9, T10) GetResult() => whenAllAwaiter.GetResult();
    }

    public static TupleConfiguredValueTaskAwaitable<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>
        ConfigureAwait<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
            this (ValueTask<T1>, ValueTask<T2>, ValueTask<T3>, ValueTask<T4>, ValueTask<T5>, ValueTask<T6>,
                ValueTask<T7>, ValueTask<T8>, ValueTask<T9>, ValueTask<T10>)
                tasks, bool continueOnCapturedContext) =>
        new(tasks,
            continueOnCapturedContext);

    public readonly struct TupleConfiguredValueTaskAwaitable<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
        (ValueTask<T1>, ValueTask<T2>, ValueTask<T3>, ValueTask<T4>, ValueTask<T5>, ValueTask<T6>, ValueTask<T7>,
            ValueTask<T8>, ValueTask<T9>, ValueTask<T10>) tasks,
        bool continueOnCapturedContext)
    {
        public Awaiter GetAwaiter() => new(tasks, continueOnCapturedContext);

        public readonly struct Awaiter(
            (ValueTask<T1>, ValueTask<T2>, ValueTask<T3>, ValueTask<T4>, ValueTask<T5>, ValueTask<T6>, ValueTask<T7>,
                ValueTask<T8>, ValueTask<T9>, ValueTask<T10>)
                tasks,
            bool continueOnCapturedContext)
            : INotifyCompletion
        {
            readonly ConfiguredValueTaskAwaitable<(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10)>.ConfiguredValueTaskAwaiter
                whenAllAwaiter = ValueTaskPlus
                    .WhenEach(in tasks).ConfigureAwait(continueOnCapturedContext)
                    .GetAwaiter();

            public bool IsCompleted => whenAllAwaiter.IsCompleted;
            public void OnCompleted(Action continuation) => whenAllAwaiter.OnCompleted(continuation);

            public (T1, T2, T3, T4, T5, T6, T7, T8, T9, T10) GetResult() => whenAllAwaiter.GetResult();
        }
    }

    #endregion
}
