// ReSharper disable PossibleMultipleEnumeration
// ReSharper disable UnusedVariable

using System.Diagnostics.CodeAnalysis;

namespace CSharpPlus.Tests.EnumerablePlus;

[SuppressMessage("Minor Code Smell", "S1481:Unused local variables should be removed")]
public class TupleEnumerablePlus : BaseTest
{
    [Test]
    public void ShouldDeconstruct1()
    {
        const int size = 1;
        var items = Enumerable.Range(0, size).Select(_ => faker.Random.Int()).ToArray()
            .AsEnumerable();
#pragma warning disable S2583
        if (items is var (n))
#pragma warning restore S2583
            items.Should().BeEquivalentTo(new[]
            {
                n,
            });
        else
            Assert.Fail();
    }

    [Test]
    public void ShouldDeconstruct2()
    {
        const int size = 2;
        var items = Enumerable.Range(0, size).Select(_ => faker.Random.Int()).ToArray()
            .AsEnumerable();
        var (n1, n2) = items;
        items.Should().BeEquivalentTo(new[]
        {
            n1, n2,
        });
    }

    [Test]
    public void ShouldDeconstruct3()
    {
        const int size = 3;
        var items = Enumerable.Range(0, size).Select(_ => faker.Random.Int()).ToArray()
            .AsEnumerable();
        var (n1, n2, n3) = items;
        items.Should().BeEquivalentTo(new[]
        {
            n1, n2, n3,
        });
    }

    [Test]
    public void ShouldDeconstruct4()
    {
        const int size = 4;
        var items = Enumerable.Range(0, size).Select(_ => faker.Random.Int()).ToArray()
            .AsEnumerable();
        var (n1, n2, n3, n4) = items;
        items.Should().BeEquivalentTo(new[]
        {
            n1, n2, n3, n4,
        });
    }

    [Test]
    public void ShouldDeconstruct5()
    {
        const int size = 5;
        var items = Enumerable.Range(0, size).Select(_ => faker.Random.Int()).ToArray()
            .AsEnumerable();
        var (n1, n2, n3, n4, n5) = items;
        items.Should().BeEquivalentTo(new[]
        {
            n1, n2, n3, n4, n5,
        });
    }

    [Test]
    public void ShouldDeconstruct6()
    {
        const int size = 6;
        var items = Enumerable.Range(0, size).Select(_ => faker.Random.Int()).ToArray()
            .AsEnumerable();
        var (n1, n2, n3, n4, n5, n6) = items;
        items.Should().BeEquivalentTo(new[]
        {
            n1, n2, n3, n4, n5, n6,
        });
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
        var items = Enumerable.Range(0, size - 1).Select(_ => faker.Random.Int()).ToArray()
            .AsEnumerable();
        var action = () => items is var (n1, n2);
        action.Should().Throw<InvalidOperationException>();
    }

    [Test]
    public void ShouldDeconstructThrow3()
    {
        const int size = 3;
        var items = Enumerable.Range(0, size - 1).Select(_ => faker.Random.Int()).ToArray()
            .AsEnumerable();
        var action = () => items is var (n1, n2, n3);
        action.Should().Throw<InvalidOperationException>();
    }

    [Test]
    public void ShouldDeconstructThrow4()
    {
        const int size = 4;
        var items = Enumerable.Range(0, size - 1).Select(_ => faker.Random.Int()).ToArray()
            .AsEnumerable();
        var action = () => items is var (n1, n2, n3, n4);
        action.Should().Throw<InvalidOperationException>();
    }

    [Test]
    public void ShouldDeconstructThrow5()
    {
        const int size = 5;
        var items = Enumerable.Range(0, size - 1).Select(_ => faker.Random.Int()).ToArray()
            .AsEnumerable();
        var action = () => items is var (n1, n2, n3, n4, n5);
        action.Should().Throw<InvalidOperationException>();
    }


    [Test]
    public void ShouldDeconstructThrow6()
    {
        const int size = 6;
        var items = Enumerable.Range(0, size - 1).Select(_ => faker.Random.Int()).ToArray()
            .AsEnumerable();
        var action = () => items is var (n1, n2, n3, n4, n5, n6);
        action.Should().Throw<InvalidOperationException>();
    }
}
