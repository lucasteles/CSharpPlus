using FsCheck;

public class MyGenerators
{
    protected MyGenerators() { }

    public static Arbitrary<Task<T>> TaskGenerator<T>()
    {
        var generator =
            from v in Arb.From<T>().Generator
            select Task.FromResult(v);

        return Arb.From(generator);
    }

    public static Arbitrary<Index> IndexGenerator()
    {
        var generator =
            from v in Arb.From<int>().Generator
            select new Index(Math.Abs(v), v < 0);
        return Arb.From(generator);
    }
}
