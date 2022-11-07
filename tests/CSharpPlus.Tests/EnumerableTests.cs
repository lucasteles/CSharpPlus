namespace CSharpPlus.Tests;

public class EnumerableTests
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
}
