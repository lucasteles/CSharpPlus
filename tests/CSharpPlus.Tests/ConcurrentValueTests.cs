namespace CSharpPlus.Tests;

public class ConcurrentValueTests
{
    const int Count = 10_000;

    record Integer(int Value)
    {
        public Integer Increment() => new(Value + 1);
        public Integer Decrement() => new(Value - 1);

        public static implicit operator int(Integer i) => i.Value;
        public static implicit operator Integer(int i) => new(i);
    }

    [Test]
    public void ShouldIncrement()
    {
        ConcurrentValue<Integer> atom = new(0);

        Parallel.For(0, Count * 2, n =>
            atom.Update(x => n < Count ? x.Increment() : x.Decrement()));

        atom.Value.Value.Should().Be(0);
    }

    [Test]
    public async Task ShouldIncrementTask()
    {
        ConcurrentValue<Integer> atom = new(0);

        await Task.WhenAll(
            Enumerable.Range(0, Count * 2)
                .Select(n => Task.Run(() =>
                    atom.Update(x => n < Count
                        ? x.Increment()
                        : x.Decrement()))));

        atom.Value.Value.Should().Be(0);
    }
}
