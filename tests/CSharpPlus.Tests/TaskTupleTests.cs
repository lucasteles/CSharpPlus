namespace CSharpPlus.Tests;

public class TaskTupleTests : BaseTest
{
    public int Int() => faker.Random.Int();
    [Test]
    public async Task TupleTask()
    {
        var value = faker.Random.Int();
        var task = new ValueTuple<Task<int>>(Task.FromResult(value));
        var result = await task;
        result.Should().Be(value);
    }

    [Test]
    public async Task TupleTask2()
    {
        var values = (Int(), Int());
        var (v1, v2) = values;
        var result = await (Task.FromResult(v1), Task.FromResult(v2));
        result.Should().Be(values);
    }

    [Test]
    public async Task TupleTask3()
    {
        var values = (Int(), Int(), Int());
        var (v1, v2, v3) = values;
        var result = await (Task.FromResult(v1), Task.FromResult(v2), Task.FromResult(v3));
        result.Should().Be(values);
    }

}
