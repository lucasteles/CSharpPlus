namespace CSharpPlus.Tests;

public class TaskExtensionsTests
{
    [Test]
    public async Task WhenAllNoReturn()
    {
        var values = Enumerable.Range(0, 5).Select(Task.Delay).ToArray();
        await values.WhenAll();
        values.Should().AllSatisfy(x => x.IsCompleted.Should().BeTrue());
    }

    [Test]
    public async Task WhenAnyNoReturn()
    {
        var values = Enumerable.Range(0, 5).Select(x => TimeSpan.FromSeconds(x)).Select(Task.Delay).ToArray();
        await values.WhenAny();
        values.Should().ContainSingle(x => x.IsCompleted);
    }

    [Test]
    public async Task WhenAllWithReturn()
    {
        var values = Enumerable.Range(0, 5).Select(async n =>
        {
            await Task.Delay(n);
            return n;
        }).ToArray();

        var result = await values.WhenAll();
        result.Should().BeEquivalentTo(new[] { 0, 1, 2, 3, 4 });
    }

    [Test]
    public async Task WhenAnyWithReturn()
    {
        var values = Enumerable.Range(0, 5).Select(async n =>
        {
            await Task.Delay(TimeSpan.FromSeconds(5 - n));
            return n;
        }).ToArray();

        var result = await values.WhenAny();
        result.Should().Be(4);
    }

    [PropertyTest]
    public void IsNullOrWhiteSpace(string? value) =>
        value.IsNullOrWhiteSpace().Should().Be(string.IsNullOrWhiteSpace(value));
}
