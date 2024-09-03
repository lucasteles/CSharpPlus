namespace CSharpPlus;

/// <summary>
/// Provide a way to manage shared, synchronous, independent state
/// </summary>
public sealed class ConcurrentValue<T>(T initialValue) where T : class
{
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
            if (ReferenceEquals(result, curr))
                break;

            sw.SpinOnce();
        }
    }

    public void Reset(T resetValue) => currentValue = resetValue;
}
