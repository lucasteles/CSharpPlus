namespace CSharpPlus;

/// <summary>
/// Provide a way to manage shared, synchronous, independent state
/// </summary>
public sealed class ConcurrentValue<T>(T value) where T : class
{
    public T Value => value;

    public void Update(Func<T, T> updater)
    {
        SpinWait sw = new();
        while (true)
        {
            var curr = value;
            var next = updater(curr);
            var result = Interlocked.CompareExchange(ref value, next, curr);
            if (ReferenceEquals(result, curr))
                break;

            sw.SpinOnce();
        }
    }

    public void Reset(T resetValue) => value = resetValue;
}
