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
        FluentAssertions();
    }

    static void FluentAssertions() =>
        AssertionOptions.AssertEquivalencyUsing(options => options
            .Using<DateTime>(ctx =>
                ctx.Subject.Should().BeCloseTo(ctx.Expectation, TimeSpan.FromSeconds(100)))
            .WhenTypeIs<DateTime>()
            .Using<decimal>(ctx =>
                ctx.Subject.Should().BeApproximately(ctx.Expectation, .0001M))
            .WhenTypeIs<decimal>()
            .Using<double>(ctx =>
                ctx.Subject.Should().BeApproximately(ctx.Expectation, .0001))
            .WhenTypeIs<double>());
}

