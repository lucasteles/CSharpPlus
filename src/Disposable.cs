using System;
using System.Threading.Tasks;

namespace CSharpPlus;

/// <summary>
/// Disposable static functions
/// </summary>
public static class Disposable
{
    /// <inheritdoc />
    public readonly struct Deferred : IDisposable
    {
        readonly Action action;

        /// <summary>
        /// Create new deferred context
        /// </summary>
        public Deferred(Action action) => this.action = action;

        /// <inheritdoc />
        public void Dispose() => action?.Invoke();
    }

    /// <inheritdoc />
    public readonly struct DeferredTask : IAsyncDisposable
    {
        readonly Func<ValueTask> action;

        /// <summary>
        /// Create new deferred context
        /// </summary>
        public DeferredTask(Func<ValueTask> action) => this.action = action;

        /// <inheritdoc />
        public async ValueTask DisposeAsync()
        {
            if (action is not null)
                await action();
        }
    }

    /// <summary>
    /// Defer action execution with Dispose
    /// </summary>
    public static Deferred Defer(Action action) => new(action);

    /// <summary>
    /// Defer async action execution with DisposeAsync
    /// </summary>
    public static DeferredTask Defer(Func<ValueTask> action) => new(action);
}
