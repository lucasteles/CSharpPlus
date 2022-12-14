// ReSharper disable PossibleMultipleEnumeration

using FsCheck;

namespace CSharpPlus.Tests.EnumerablePlus;

public class LinqEnumerablePlusTests : BaseTest
{
    [PropertyTest]
    public void StringJoinChar(string[] value, char chr) =>
        value.JoinString(chr).Should().Be(string.Join(chr, value));

    [PropertyTest]
    public void StringJoinString(string[] value, string str) =>
        value.JoinString(str).Should().Be(string.Join(str, value));

    [PropertyTest]
    public void CharJoinChar(char[] values, char chr) =>
        values.JoinString(chr).Should().Be(string.Join(chr, values));

    [PropertyTest]
    public void CharJoinString(char[] value, string str) =>
        value.JoinString(str).Should().Be(string.Join(str, value));

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
}
