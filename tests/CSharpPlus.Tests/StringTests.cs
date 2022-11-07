namespace CSharpPlus.Tests;

public class StringTests
{
    [PropertyTest]
    public void IsNullOrEmpty(string? value) =>
        value.IsNullOrEmpty().Should().Be(string.IsNullOrEmpty(value));

    [PropertyTest]
    public void IsNullOrWhiteSpace(string? value) =>
        value.IsNullOrWhiteSpace().Should().Be(string.IsNullOrWhiteSpace(value));


}
