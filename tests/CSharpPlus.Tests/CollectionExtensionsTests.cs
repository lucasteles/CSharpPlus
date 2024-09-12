namespace CSharpPlus.Tests;

#pragma warning disable S6605
#pragma warning disable S6602

public class CollectionExtensionsTests
{
    [Test]
    public void ShouldAddRange()
    {
        List<int> currentItems = [1, 2, 3];
        int[] newItems = [4, 5, 6];
        int[] expected = [1, 2, 3, 4, 5, 6];

        currentItems.AddRange(newItems);
        currentItems.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void ShouldRemoveRange()
    {
        List<int> currentItems = [1, 2, 3, 4, 5, 6];
        int[] expected = [1, 2, 3];
        var removeRange = 3..6;

        currentItems.RemoveRange(removeRange);
        currentItems.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void ShouldRemoveRangeMid()
    {
        List<int> currentItems = [1, 2, 3, 4, 5, 6];
        int[] expected = [1, 6];
        var removeRange = 1..^1;

        currentItems.RemoveRange(removeRange);
        currentItems.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void ShouldRemoveLast()
    {
        List<int> currentItems = [1, 2, 3, 4];
        int[] expected = [1, 2, 3];

        currentItems.RemoveAt(^1);
        currentItems.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void ShouldRemoveBeforeLast()
    {
        List<int> currentItems = [1, 2, 3, 4];
        int[] expected = [1, 2, 4];

        currentItems.RemoveAt(^2);
        currentItems.Should().BeEquivalentTo(expected);
    }
}
