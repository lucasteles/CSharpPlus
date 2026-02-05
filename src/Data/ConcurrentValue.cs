namespace CSharpPlus.Data;

/// <summary>
/// Provide a way to manage shared, synchronous, independent state
/// </summary>
public interface IConcurrentValue<T>
{
    T Value { get; }
    void Update(Func<T, T> updater);
    void Reset(T resetValue);
}

/// <inheritdoc cref="IConcurrentValue{T}"/>
public sealed class ConcurrentValue<T>(T initialValue, IEqualityComparer<T>? exchangeComparer = null)
    : IConcurrentValue<T> where T : class
{
    readonly IEqualityComparer<T> comparer = exchangeComparer ?? ReferenceEqualityComparer.Instance;

    T currentValue = initialValue;
    public T Value => currentValue;

    public void Update(Func<T, T> updater)
    {
        SpinWait sw = new();
        while (true)
        {
            var curr = currentValue;
            var next = updater(curr);
            var result = Interlocked.CompareExchange(ref currentValue, next, curr);
            if (comparer.Equals(result, curr))
                break;

            sw.SpinOnce();
        }
    }

    public void Reset(T resetValue) => currentValue = resetValue;
}

public static class ConcurrentValue
{
    public static IConcurrentValue<T> Create<T>(T value, IEqualityComparer<T>? comparer = null) where T : class =>
        new ConcurrentValue<T>(value, comparer);

    public static IConcurrentValue<T> Create<T>(IEqualityComparer<T?>? comparer = null) where T : class, new() =>
        new ConcurrentValue<T>(new(), comparer);

    public static IConcurrentValue<int> Create(int value, IEqualityComparer<int>? comparer = null) =>
        new ConcurrentInt32(value, comparer);

    public static IConcurrentValue<long> Create(long value, IEqualityComparer<long>? comparer = null) =>
        new ConcurrentInt64(value, comparer);

    /// <inheritdoc cref="IConcurrentValue{T}"/>
    public sealed class ConcurrentInt32(int initialValue, IEqualityComparer<int>? exchangeComparer = null)
        : IConcurrentValue<int>
    {
        readonly IEqualityComparer<int> comparer = exchangeComparer ?? EqualityComparer<int>.Default;

        int currentValue = initialValue;
        public int Value => currentValue;

        public void Update(Func<int, int> updater)
        {
            SpinWait sw = new();
            while (true)
            {
                var curr = currentValue;
                var next = updater(curr);
                var result = Interlocked.CompareExchange(ref currentValue, next, curr);
                if (comparer.Equals(result, curr)) break;
                sw.SpinOnce();
            }
        }

        public void Reset(int resetValue) => currentValue = resetValue;
    }

    /// <inheritdoc cref="IConcurrentValue{T}"/>
    public sealed class ConcurrentInt64(long initialValue, IEqualityComparer<long>? exchangeComparer = null)
        : IConcurrentValue<long>
    {
        readonly IEqualityComparer<long> comparer = exchangeComparer ?? EqualityComparer<long>.Default;

        long currentValue = initialValue;
        public long Value => currentValue;

        public void Update(Func<long, long> updater)
        {
            SpinWait sw = new();
            while (true)
            {
                var curr = currentValue;
                var next = updater(curr);
                var result = Interlocked.CompareExchange(ref currentValue, next, curr);
                if (comparer.Equals(result, curr)) break;
                sw.SpinOnce();
            }
        }

        public void Reset(long resetValue) => currentValue = resetValue;
    }
}
