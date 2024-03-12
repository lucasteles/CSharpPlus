namespace CSharpPlus.Tests;

public class RangeExtensionsTests
{
    [Test]
    public void ShouldEnumerateRange()
    {
        var numbers = (..10).Enumerate().ToArray();
        var expected = new[]
        {
            0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
        };
        numbers.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void ShouldBeIterable()
    {
        var list = new List<int>();
        foreach (var n in ..10)
            list.Add(n);

        var expected = new[]
        {
            0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
        };
        list.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void ShouldEnumerateBackwardsRange()
    {
        var numbers = (10..0).Enumerate().ToArray();
        var expected = new[]
        {
            10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0,
        };
        numbers.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void ShouldBeBackwardsIterable()
    {
        var list = new List<int>();
        foreach (var n in 10..0)
            list.Add(n);

        var expected = new[]
        {
            10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0,
        };
        list.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void ShouldIterateExclusive()
    {
        var list = new List<int>();
        foreach (var n in ^0..^10)
            list.Add(n);

        var expected = new[]
        {
            1, 2, 3, 4, 5, 6, 7, 8, 9,
        };
        list.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void ShouldBeBackwardsExclusiveIterable()
    {
        var list = new List<int>();
        foreach (var n in ^10..^0)
            list.Add(n);

        var expected = new[]
        {
            9, 8, 7, 6, 5, 4, 3, 2, 1,
        };
        list.Should().BeEquivalentTo(expected);
    }


    [PropertyTest]
    public void ShouldProject(Index begin, Index end, Func<int, int> map)
    {
        var sut = (begin..end).Select(map).ToArray();
        var expected = InclusiveRange(begin, end).Select(map).ToArray();
        sut.Should().BeEquivalentTo(expected);
    }

    [PropertyTest]
    public void ShouldProjectMany(Index begin, Index end, Func<int, int[]> map)
    {
        var sut = (begin..end).SelectMany(map).ToArray();
        var expected = InclusiveRange(begin, end).SelectMany(map).ToArray();
        sut.Should().BeEquivalentTo(expected);
    }

    [PropertyTest]
    public void ShouldProjectLinq(Index begin, Index end, Func<int, int> map)
    {
        var sut = from n in (begin..end) select map(n);
        var expected = InclusiveRange(begin, end).Select(map).ToArray();
        sut.Should().BeEquivalentTo(expected);
    }

    [PropertyTest]
    public void ShouldProjectManyLinq(
        Index begin1, Index end1,
        Index begin2, Index end2,
        Func<int, int, int> map)
    {
        var sut =
            from a in (begin1..end1)
            from b in (begin2..end2)
            select map(a, b);

        var expected =
            from a in InclusiveRange(begin1, end1)
            from b in InclusiveRange(begin2, end2)
            select map(a, b);

        sut.Should().BeEquivalentTo(expected);
    }

    [PropertyTest]
    public void ShouldProjectManyMethod(
        Index begin1, Index end1,
        Index begin2, Index end2,
        Func<int, int, int> map)
    {
        var sut = (begin1..end1).SelectMany(_ => (begin2..end2), map);
        var expected = InclusiveRange(begin1, end1)
            .SelectMany(_ => InclusiveRange(begin2, end2), map);
        sut.Should().BeEquivalentTo(expected);
    }

    [PropertyTest]
    public void ShouldProjectManyFlat(
        Index begin1, Index end1,
        Index begin2, Index end2)
    {
        var sut = (begin1..end1).SelectMany(_ => begin2..end2).ToArray();
        var expected = InclusiveRange(begin1, end1).SelectMany(_ => InclusiveRange(begin2, end2))
            .ToArray();
        sut.Should().BeEquivalentTo(expected);
    }

    static IEnumerable<int> InclusiveRange(Index begin, Index end)
    {
        var boundaries = new[]
        {
            end.Int(), begin.Int(),
        };
        var (min, max) = (boundaries.Min(), boundaries.Max());
        var size = Math.Abs(min - max) + 1;
        return Enumerable.Range(min, size);
    }
}
