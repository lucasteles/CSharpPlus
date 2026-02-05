using CSharpPlus.Data;

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
        var atom = ConcurrentValue.Create(new Integer(0));

        Parallel.For(0, Count * 2, n =>
            atom.Update(x => n < Count ? x.Increment() : x.Decrement()));

        atom.Value.Value.Should().Be(0);
    }

    [Test]
    public async Task ShouldIncrementTask()
    {
        var atom = ConcurrentValue.Create(new Integer(0));

        await Enumerable.Range(0, Count * 2)
            .Select(n => Task.Run(() =>
                atom.Update(x => n < Count
                    ? x.Increment()
                    : x.Decrement())))
            .WhenAll();

        atom.Value.Value.Should().Be(0);
    }

    [Test]
    public async Task ShouldIncrementInteger()
    {
        var atom = ConcurrentValue.Create(0);

        await Enumerable.Range(0, Count * 2)
            .Select(n => Task.Run(() =>
                atom.Update(x => n < Count
                    ? x + 1
                    : x - 1)))
            .WhenAll();

        atom.Value.Should().Be(0);
    }
}
