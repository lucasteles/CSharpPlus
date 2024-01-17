namespace CSharpPlus;

public sealed class Atom<T>(T value) where T : class
{
    public T Value => value;

    public void Swap(Func<T, T> updater)
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
