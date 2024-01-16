namespace CSharpPlus.Tests;

#pragma warning disable S6605
#pragma warning disable S6602

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

        items.FindAll(x => x % 2 == 0 || x.ToString().Length is 2)
            .Should().BeEquivalentTo(expected);
    }

    [PropertyTest]
    public void ShouldFilterArray(int[] items, Func<int, bool> pred)
    {
        var expected = items.Where(pred).ToArray();
        items.FindAll(pred).Should().BeEquivalentTo(expected);
    }

    [PropertyTest]
    public void ShouldCheckExistence(int[] items, Func<int, bool> pred)
    {
        var expected = items.Any(pred);
        items.Exist(pred).Should().Be(expected);
    }

    [PropertyTest]
    public void ShouldCheckFind(int[] items, Func<int, bool> pred)
    {
        var expected = items.FirstOrDefault(pred);
        items.Find(pred).Should().Be(expected);
    }

    [PropertyTest]
    public void ShouldCheckFindLast(int[] items, Func<int, bool> pred)
    {
        var expected = items.LastOrDefault(pred);
        items.FindLast(pred).Should().Be(expected);
    }

    [PropertyTest]
    public void ShouldCheckFindIndex(int[] items, Func<int, bool> pred)
    {
        var expected = items.Select((x, i) => (Value: x, Id: i)).Where(x => pred(x.Value))
            .Select(x => x.Id).FirstOrDefault(-1);

        items.FindIndex(pred).Should().Be(expected);
    }

    [PropertyTest]
    public void ShouldCheckFindLastIndex(int[] items, Func<int, bool> pred)
    {
        var expected = items.Select((x, i) => (Value: x, Id: i)).Where(x => pred(x.Value))
            .Select(x => x.Id).LastOrDefault(-1);
        items.FindLastIndex(pred).Should().Be(expected);
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

        items.ConvertAll(x => $"{(x % 2 == 0 ? "even" : "odd")}[{x}]")
            .Should().BeEquivalentTo(expected);
    }

    [PropertyTest]
    public void ShouldMapArray(int[] items)
    {
        string Selector(int x) => $"{(x % 2 == 0 ? "even" : "odd")}[{x}]";
        var expected = items.Select(Selector).ToArray();
        items.ConvertAll(Selector).Should().BeEquivalentTo(expected);
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

        items.Sort()
            .Should().BeEquivalentTo(expected);
    }

    [PropertyTest]
    public void ShouldOrderArray(int[] items)
    {
        var expected = items.OrderBy(x => x).ToArray();
        items.Sort().Should().BeEquivalentTo(expected);
    }

    [PropertyTest]
    public void ShouldOrderByArray(int[] items, Func<int, int> pred)
    {
        var expected = items.OrderBy(pred).ToArray();
        items.SortBy(pred).Should().BeEquivalentTo(expected);
    }
}
