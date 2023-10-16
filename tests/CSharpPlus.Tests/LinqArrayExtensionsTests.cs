namespace CSharpPlus.Tests;

public class LinqArrayExtensionsTests
{
    [Test]
    public void ShouldFilterSampleArray()
    {
        int[] items =
        {
            1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13,
        };

        int[] expected =
        {
            2, 4, 6, 8, 10, 11, 12, 13,
        };

        items.WhereArray(x => x % 2 == 0 || x.ToString().Length is 2)
            .Should().BeEquivalentTo(expected);
    }

    [PropertyTest]
    public void ShouldFilterArray(int[] items, Func<int, bool> pred)
    {
        var expected = items.Where(pred).ToArray();
        items.WhereArray(pred).Should().BeEquivalentTo(expected);
    }

    [Test]
    public void ShouldMapSampleTest()
    {
        int[] items =
        {
            1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
        };

        string[] expected =
        {
            "odd[1]",
            "even[2]",
            "odd[3]",
            "even[4]",
            "odd[5]",
            "even[6]",
            "odd[7]",
            "even[8]",
            "odd[9]",
            "even[10]",
        };

        items.SelectArray(x => $"{(x % 2 == 0 ? "even" : "odd")}[{x}]")
            .Should().BeEquivalentTo(expected);
    }

    [PropertyTest]
    public void ShouldMapArray(int[] items)
    {
        string Selector(int x) => $"{(x % 2 == 0 ? "even" : "odd")}[{x}]";
        var expected = items.Select(Selector).ToArray();
        items.SelectArray(Selector).Should().BeEquivalentTo(expected);
    }

    [PropertyTest]
    public void ShouldConcatArray(int[] itemsA, int[] itemsB)
    {
        var expected = itemsA.Concat(itemsB).ToArray();
        var result = itemsA.ConcatArray(itemsB);
        result.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void ShouldOrderSampleArray()
    {
        int[] items =
        {
            10, 5, 3, 8, 2, 4, 9, 6, 1, 7,
        };

        int[] expected =
        {
            1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
        };

        items.OrderArray()
            .Should().BeEquivalentTo(expected);
    }

    [PropertyTest]
    public void ShouldOrderArray(int[] items)
    {
        var expected = items.OrderBy(x => x).ToArray();
        items.OrderArray().Should().BeEquivalentTo(expected);
    }

    [PropertyTest]
    public void ShouldOrderByArray(int[] items, Func<int, int> pred)
    {
        var expected = items.OrderBy(pred).ToArray();
        items.OrderByArray(pred).Should().BeEquivalentTo(expected);
    }
}
