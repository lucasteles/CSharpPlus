// ReSharper disable PossibleMultipleEnumeration

using FsCheck;

namespace CSharpPlus.Tests.EnumerablePlus;

public class LinqEnumerablePlusTests : BaseTest
{
    [Test]
    public void StringJoinSampleTest()
    {
        var collection = new[]
        {
            4, 8, 15, 16, 23, 42,
        };

        const string expected = "4;8;15;16;23;42";

        collection.JoinString(";").Should().Be(expected);
    }

    [PropertyTest]
    public void StringJoinChar(string[] value, char chr) =>
        value.JoinString(chr).Should().Be(string.Join(chr, value));

    [PropertyTest]
    public void StringJoinString(string[] value, string str) =>
        value.JoinString(str).Should().Be(string.Join(str, value));

    [PropertyTest]
    public void CharJoinChar(char[] values, char chr) =>
        values.JoinAsString(chr).Should().Be(string.Join(chr, values));

    [PropertyTest]
    public void CharJoinString(char[] value, string str) =>
        value.JoinAsString(str).Should().Be(string.Join(str, value));

    [PropertyTest]
    public void StringConcat(string[] values) =>
        values.ConcatString().Should().Be(string.Concat(values));

    [PropertyTest]
    public void StringConcatChar(char[] values) =>
        values.ConcatString().Should().Be(string.Concat(values));

    [PropertyTest]
    public void IsEmpty(char[] values) =>
        values.IsEmpty().Should().Be(!values.Any());

    [PropertyTest]
    public void SelectMany(int[][] values) =>
        values.SelectMany().Should().BeEquivalentTo(values.SelectMany(x => x));


    [PropertyTest]
    public void Shuffle(DistinctNonEmptyArray<int> data) =>
        data.Items.Shuffle(new System.Random(42))
            .Should()
            .NotBeEquivalentTo(data.Items, opt => opt.WithStrictOrdering());

    [PropertyTest]
    public void MinMax(NonEmptyArray<int> data)
    {
        var values = data.Item;
        values.MinMax().Should().BeEquivalentTo((Min: values.Min(), Max: values.Max()));
    }

    [PropertyTest]
    public void MinAndMaxBy(NonEmptyString[] values) =>
        values.MinAndMaxBy(x => x.Item.Length)
            .Should()
            .BeEquivalentTo((
                Min: values.MinBy(s => s.Item.Length),
                Max: values.MaxBy(s => s.Item.Length)));

    [PropertyTest]
    public void MinAndMax(NonEmptyArray<NonEmptyString> values) =>
        values.Item.MinAndMax(x => x.Item.Length)
            .Should()
            .BeEquivalentTo((
                Min: values.Item.Min(s => s.Item.Length),
                Max: values.Item.Max(s => s.Item.Length)));


    [PropertyTest]
    public void MinOrDefaultNonEmpty(NonEmptyArray<NonEmptyString> values) =>
        values.Item.MinOrDefault(x => x.Item.Length)
            .Should()
            .Be(values.Item.Min(s => s.Item.Length));

    [PropertyTest]
    public void MaxOrDefaultNonEmpty(NonEmptyArray<NonEmptyString> values) =>
        values.Item.MaxOrDefault(x => x.Item.Length)
            .Should()
            .Be(values.Item.Max(s => s.Item.Length));

    [Test]
    public void MinOrDefaultEmpty()
    {
        var empty = Array.Empty<string>();
        var @default = faker.Random.Int();

        empty.MinOrDefault(x => x.Length, @default)
            .Should()
            .Be(@default);
    }

    [Test]
    public void MaxOrDefaultEmpty()
    {
        var empty = Array.Empty<string>();
        var @default = faker.Random.Int();

        empty.MaxOrDefault(x => x.Length, @default)
            .Should()
            .Be(@default);
    }

    [PropertyTest]
    public void Repeat0(int[] items) => items.Repeat(0).Should().BeEmpty();

    [PropertyTest]
    public void Repeat1(int[] items) => items.Repeat(1).Should().BeEquivalentTo(items);

    [PropertyTest]
    public void Repeat2(int[] items) =>
#pragma warning disable S2114
        items.Repeat(2).Should().BeEquivalentTo(items.Concat(items));
#pragma warning restore S2114

    [PropertyTest]
    public void Repeat10(int[] items, PositiveInt n) =>
        items.Repeat(n.Item).Should().HaveCount(n.Item * items.Length);


    [PropertyTest]
    public void RepeatForever(NonEmptyArray<int> array, PositiveInt times)
    {
        var baseNumbers = Enumerable.Range(0, times.Item).SelectMany(_ => array.Item).ToArray();
        var sut = baseNumbers.Zip(array.Item.RepeatForever()).ToArray();

        sut.Should().AllSatisfy(v => v.First.Should().Be(v.Second));
    }

    record TestRefType(string Id);

    [Test]
    public void FilterNullRefTypes()
    {
        TestRefType?[] items =
        {
            new("A"), null, new("B"), null, new("C"), null, null, new("D"),
        };

        TestRefType[] expected =
        {
            new("A"), new("B"), new("C"), new("D"),
        };

        items.WhereNotNull().Should().BeEquivalentTo(expected);
    }

    record struct TestValueType(string Id);

    [Test]
    public void FilterNullValueTypes()
    {
        TestValueType?[] items =
        {
            new("A"), null, new("B"), null, new("C"), null, null, new("D"),
        };

        TestValueType[] expected =
        {
            new("A"), new("B"), new("C"), new("D"),
        };

        items.WhereNotNull().Should().BeEquivalentTo(expected);
    }
}
