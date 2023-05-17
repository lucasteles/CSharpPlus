using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharpPlus;

sealed class AsyncDisposable : IAsyncDisposable
{
    readonly Func<ValueTask> onDispose;
    bool disposed;

    public AsyncDisposable(Func<ValueTask> onDispose) =>
        this.onDispose = onDispose;

    /// <inheritdoc />
    public async ValueTask DisposeAsync()
    {
        if (disposed) return;
        disposed = true;
        await onDispose();
    }
}

sealed class SyncDisposable : IDisposable
{
    readonly Action onDispose;
    bool disposed;

    public SyncDisposable(Action onDispose) =>
        this.onDispose = onDispose;

    public void Dispose()
    {
        if (disposed) return;
        disposed = true;
        onDispose();
    }
}

/// <summary>
/// Group IDisposables in one IDisposable
/// </summary>
public sealed class DisposableGroup : IDisposable
{
    readonly ISet<IDisposable> disposables;

    /// <summary>
    /// Crete new IDisposableGroup
    /// </summary>
    public DisposableGroup() => disposables = new HashSet<IDisposable>();

    /// <summary>
    /// Crete new IDisposableGroup
    /// </summary>
    public DisposableGroup(ISet<IDisposable> disposables) => this.disposables = disposables;

    /// <summary>
    /// Add IDisposable
    /// </summary>
    public void Add(IDisposable disposable) => disposables.Add(disposable);

    /// <inheritdoc />
    public void Dispose() => disposables.ForEach(d => d.Dispose());
}

/// <summary>
/// Group IDisposables and IAsyncDisposables in one IAsyncDisposable
/// </summary>
public sealed class DisposableAsyncGroup : IAsyncDisposable
{
    readonly ISet<IAsyncDisposable> asyncDisposables;
    readonly ISet<IDisposable> disposables;

    /// <summary>
    /// Add IAsyncDisposable
    /// </summary>
    public DisposableAsyncGroup()
    {
        asyncDisposables = new HashSet<IAsyncDisposable>();
        disposables = new HashSet<IDisposable>();
    }

    /// <summary>
    /// Add IAsyncDisposable
    /// </summary>
    public DisposableAsyncGroup(ISet<IAsyncDisposable> disposables)
    {
        asyncDisposables = disposables;
        this.disposables = new HashSet<IDisposable>();
    }

    /// <summary>
    /// Add IAsyncDisposable
    /// </summary>
    public DisposableAsyncGroup(ISet<IDisposable> disposables)
    {
        asyncDisposables = new HashSet<IAsyncDisposable>();
        this.disposables = disposables;
    }

    /// <inheritdoc />
    public async ValueTask DisposeAsync()
    {
        disposables.ForEach(d => d.Dispose());
        foreach (var d in asyncDisposables)
            await d.DisposeAsync().ConfigureAwait(false);
    }

    /// <summary>
    /// Add IAsyncDisposable
    /// </summary>
    public void Add(IAsyncDisposable disposable) => asyncDisposables.Add(disposable);

    /// <summary>
    /// Add IDisposable
    /// </summary>
    public void Add(IDisposable disposable) => disposables.Add(disposable);

    /// <summary>
    /// Add IDisposable or IAsyncDisposable
    /// </summary>
    public void Add<T>(T disposable) where T : IDisposable, IAsyncDisposable =>
        asyncDisposables.Add(disposable);
}

/// <summary>
/// Create disposable from actions
/// </summary>
public static class Disposable
{
    /// <summary>
    /// Return IDisposable which will run the action on Dispose
    /// </summary>
    /// <returns></returns>
    public static IDisposable Defer(Action action) => new SyncDisposable(action);

    /// <summary>
    /// Return IAsyncDisposable which will run the action on Dispose
    /// </summary>
    /// <returns></returns>
    public static IAsyncDisposable Defer(Func<ValueTask> action) => new AsyncDisposable(action);

    /// <summary>
    /// Return IAsyncDisposable which will run the action on Dispose
    /// </summary>
    /// <returns></returns>
    public static IAsyncDisposable Defer(Func<Task> action) =>
        new AsyncDisposable(async () => await action());

    /// <summary>
    /// Group IAsyncDisposables
    /// </summary>
    /// <returns></returns>
    public static IAsyncDisposable Group(params IAsyncDisposable[] disposables) =>
        new DisposableAsyncGroup(disposables.ToHashSet());

    /// <summary>
    /// Group IDisposables
    /// </summary>
    /// <returns></returns>
    public static IDisposable Group(params IDisposable[] disposables) =>
        new DisposableGroup(disposables.ToHashSet());
}
