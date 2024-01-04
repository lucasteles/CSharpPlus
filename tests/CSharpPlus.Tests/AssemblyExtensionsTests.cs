using System.Reflection;
using Bogus.Platform;

namespace CSharpPlus.Tests;

public class AssemblyExtensionsTests
{
    static readonly Assembly assembly = typeof(AssemblyExtensionsTests).GetAssembly();

    static readonly Type[] expectedTypes =
    {
        typeof(TestStruct),
        typeof(TestRecord),
        typeof(TestClass),
        typeof(TestClass2),
        typeof(TestClass3),
        typeof(TestClass4),
    };

    [Test]
    public void ShouldGetCorrectTypes()
    {
        var types = assembly.GetAllImplementations<ITestInterface>();

        types.Should().BeEquivalentTo(
            expectedTypes.Append(typeof(TestClassCtor)),
            opt => opt.WithoutStrictOrdering());
    }

    [Test]
    public void ShouldInstantiateAllPossibleTypes()
    {
        var types = assembly
            .InstantiateAllImplementations<ITestInterface>()
            .Select(x => x.GetType());

        types.Should().BeEquivalentTo(expectedTypes, opt => opt.WithoutStrictOrdering());
    }
}

interface ITestInterface;

class TestClass : ITestInterface;

struct TestStruct : ITestInterface;

#pragma warning disable S2094
record TestRecord : ITestInterface;
#pragma warning restore S2094

class TestClassCtor : ITestInterface
{
    readonly string value;
    public TestClassCtor(string value) => this.value = value;
}

#pragma warning disable S2326
class TestClassBad2<T> : ITestInterface
#pragma warning restore S2326
{
}

interface ITestOtherInterface : ITestInterface;

class TestClass2 : ITestOtherInterface;

class TestClass3 : TestClassBad2<int>;

abstract class TestAbstract : ITestInterface;

class TestClass4 : TestAbstract;
