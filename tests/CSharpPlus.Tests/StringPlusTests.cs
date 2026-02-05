namespace CSharpPlus.Tests;

public class StringPlusTests
{
    [PropertyTest]
    public void IsNullOrEmpty(string? value) =>
        value.IsNullOrEmpty().Should().Be(string.IsNullOrEmpty(value));

    [PropertyTest]
    public void IsNullOrWhiteSpace(string? value) =>
        value.IsNullOrWhiteSpace().Should().Be(string.IsNullOrWhiteSpace(value));


}
