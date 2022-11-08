// ReSharper disable PossibleMultipleEnumeration

using FsCheck;

namespace CSharpPlus.Tests;

public class EnumerableTests : BaseTest
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
    public void MinMaxBy(NonEmptyString[] values) =>
        values.MinMaxBy(x => x.Item.Length)
            .Should()
            .BeEquivalentTo((
                Min: values.MinBy(s => s.Item.Length),
                Max: values.MaxBy(s => s.Item.Length)));

    [Test]
    public void ShouldDeconstruct1()
    {
        const int size = 1;
        var items = Enumerable.Range(0, size).Select(_ => faker.Random.Int()).ToArray().AsEnumerable();
        if (items is var (n))
            items.Should().BeEquivalentTo(new[] { n });
        else
            Assert.Fail();
    }

    [Test]
    public void ShouldDeconstruct2()
    {
        const int size = 2;
        var items = Enumerable.Range(0, size).Select(_ => faker.Random.Int()).ToArray().AsEnumerable();
        var (n1, n2) = items;
        items.Should().BeEquivalentTo(new[] { n1, n2 });
    }

    [Test]
    public void ShouldDeconstruct3()
    {
        const int size = 3;
        var items = Enumerable.Range(0, size).Select(_ => faker.Random.Int()).ToArray().AsEnumerable();
        var (n1, n2, n3) = items;
        items.Should().BeEquivalentTo(new[] { n1, n2, n3 });
    }

    [Test]
    public void ShouldDeconstruct4()
    {
        const int size = 4;
        var items = Enumerable.Range(0, size).Select(_ => faker.Random.Int()).ToArray().AsEnumerable();
        var (n1, n2, n3, n4) = items;
        items.Should().BeEquivalentTo(new[] { n1, n2, n3, n4 });
    }

    [Test]
    public void ShouldDeconstruct5()
    {
        const int size = 5;
        var items = Enumerable.Range(0, size).Select(_ => faker.Random.Int()).ToArray().AsEnumerable();
        var (n1, n2, n3, n4, n5) = items;
        items.Should().BeEquivalentTo(new[] { n1, n2, n3, n4, n5 });
    }


    [Test]
    public void ShouldDeconstructThrow1()
    {
        var items = Enumerable.Empty<int>();
        var action = () => items is var (n);
        action.Should().Throw<InvalidOperationException>();
    }

    [Test]
    public void ShouldDeconstructThrow2()
    {
        const int size = 2;
        var items = Enumerable.Range(0, size - 1).Select(_ => faker.Random.Int()).ToArray().AsEnumerable();
        var action = () => items is var (n1, n2);
        action.Should().Throw<InvalidOperationException>();
    }

    [Test]
    public void ShouldDeconstructThrow3()
    {
        const int size = 3;
        var items = Enumerable.Range(0, size - 1).Select(_ => faker.Random.Int()).ToArray().AsEnumerable();
        var action = () => items is var (n1, n2, n3);
        action.Should().Throw<InvalidOperationException>();
    }

    [Test]
    public void ShouldDeconstructThrow4()
    {
        const int size = 4;
        var items = Enumerable.Range(0, size - 1).Select(_ => faker.Random.Int()).ToArray().AsEnumerable();
        var action = () => items is var (n1, n2, n3, n4);
        action.Should().Throw<InvalidOperationException>();
    }

    [Test]
    public void ShouldDeconstructThrow5()
    {
        const int size = 5;
        var items = Enumerable.Range(0, size - 1).Select(_ => faker.Random.Int()).ToArray().AsEnumerable();
        var action = () => items is var (n1, n2, n3, n4, n5);
        action.Should().Throw<InvalidOperationException>();
    }
}
