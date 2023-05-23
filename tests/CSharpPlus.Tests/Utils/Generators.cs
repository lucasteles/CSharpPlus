using FsCheck;

public readonly record struct DistinctNonEmptyArray<T>(T[] Items)
{
    public override string ToString() => string.Join(",", Items);
}

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
            select new Index(Math.Abs(v));
        return Arb.From(generator);
    }

    public static Arbitrary<DistinctNonEmptyArray<T>> DistinctNonEmptyArrayGenerator<T>()
    {
        const int minSize = 5;
        var generator =
            from v in Gen.Sized(testSize =>
            {
                var size = Math.Max(testSize, minSize);
                return Gen.ArrayOf(size, Arb.From<T>().Generator)
                    .Where(n => n.Distinct().Count() >= size);
            })
            select new DistinctNonEmptyArray<T>(v);

        return Arb.From(generator);
    }
}
