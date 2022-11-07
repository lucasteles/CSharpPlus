using FsCheck;

public static class PropAsync
{
    public static void ForAll<TValue>(Func<TValue, Task> f) =>
        Prop.ForAll<TValue>(v =>
        {
            f(v).GetAwaiter().GetResult();
            return true;
        }).QuickCheckThrowOnFailure();

    public static void ForAll<TValue>(Func<TValue, Task<bool>> f) =>
        Prop.ForAll<TValue>(v => f(v).GetAwaiter().GetResult())
            .QuickCheckThrowOnFailure();
}

public class MyGenerators
{
    public static Arbitrary<Task<T>> TaskGenerator<T>()
    {
        var generator =
            from v in Arb.From<T>().Generator
            select Task.FromResult(v);

        return Arb.From(generator);
    }
}
