namespace CSharpPlus.Tests;

public class RangeExtensionsTests
{
    [Test]
    public void ShouldEnumerateRange()
    {
        var numbers = (..10).Enumerate().ToArray();
        var expected = new[] {0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
        numbers.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void ShouldBeIterable()
    {
        var list = new List<int>();
        foreach (var n in ..10)
            list.Add(n);

        var expected = new[] {0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
        list.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void ShouldEnumerateBackwardsRange()
    {
        var numbers = (10..0).Enumerate().ToArray();
        var expected = new[] {10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0};
        numbers.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void ShouldBeBackwardsIterable()
    {
        var list = new List<int>();
        foreach (var n in 10..0)
            list.Add(n);

        var expected = new[] {10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0};
        list.Should().BeEquivalentTo(expected);
    }


    [PropertyTest]
    public void IsNullOrWhiteSpace(string? value) =>
        value.IsNullOrWhiteSpace().Should().Be(string.IsNullOrWhiteSpace(value));
}
