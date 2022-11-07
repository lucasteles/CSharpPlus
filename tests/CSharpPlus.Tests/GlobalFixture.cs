using FsCheck;

namespace CSharpPlus.Tests;

[SetUpFixture]
public class GlobalFixture
{
    [OneTimeSetUp]
    public void Setup()
    {
        Randomizer.Seed = new(42);
        Arb.Register<MyGenerators>();
    }
}
