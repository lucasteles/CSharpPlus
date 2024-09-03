namespace CSharpPlus.Tests;

public class TaskTupleTests : BaseTest
{
    [Test]
    public async Task TupleTask()
    {
        var value = Int();
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


    [Test]
    public async Task TupleTask4()
    {
        var values = (Int(), Int(), Int(), Int());
        var (v1, v2, v3, v4) = values;
        var result =
            await (Task.FromResult(v1), Task.FromResult(v2), Task.FromResult(v3), Task.FromResult(v4));
        result.Should().Be(values);
    }


    [Test]
    public async Task TupleTask5()
    {
        var values = (Int(), Int(), Int(), Int(), Int());
        var (v1, v2, v3, v4, v5) = values;
        var result = await (
            Task.FromResult(v1), Task.FromResult(v2),
            Task.FromResult(v3), Task.FromResult(v4),
            Task.FromResult(v5)
        );
        result.Should().Be(values);
    }

    [Test]
    public async Task TupleTask6()
    {
        var values = (Int(), Int(), Int(), Int(), Int(), Int());
        var (v1, v2, v3, v4, v5, v6) = values;
        var result = await (
            Task.FromResult(v1), Task.FromResult(v2),
            Task.FromResult(v3), Task.FromResult(v4),
            Task.FromResult(v5), Task.FromResult(v6)
        );
        result.Should().Be(values);
    }

    [Test]
    public async Task TupleTask7()
    {
        var values = (Int(), Int(), Int(), Int(), Int(), Int(), Int());
        var (v1, v2, v3, v4, v5, v6, v7) = values;
        var result = await (
            Task.FromResult(v1), Task.FromResult(v2),
            Task.FromResult(v3), Task.FromResult(v4),
            Task.FromResult(v5), Task.FromResult(v6),
            Task.FromResult(v7)
        );
        result.Should().Be(values);
    }

    [Test]
    public async Task TupleTask8()
    {
        var values = (Int(), Int(), Int(), Int(), Int(), Int(), Int(), Int());
        var (v1, v2, v3, v4, v5, v6, v7, v8) = values;
        var result = await (
            Task.FromResult(v1), Task.FromResult(v2),
            Task.FromResult(v3), Task.FromResult(v4),
            Task.FromResult(v5), Task.FromResult(v6),
            Task.FromResult(v7), Task.FromResult(v8)
        );
        result.Should().Be(values);
    }

    [Test]
    public async Task TupleTask9()
    {
        var values = (Int(), Int(), Int(), Int(), Int(), Int(), Int(), Int(), Int());
        var (v1, v2, v3, v4, v5, v6, v7, v8, v9) = values;
        var result = await (
            Task.FromResult(v1), Task.FromResult(v2),
            Task.FromResult(v3), Task.FromResult(v4),
            Task.FromResult(v5), Task.FromResult(v6),
            Task.FromResult(v7), Task.FromResult(v8),
            Task.FromResult(v9)
        );
        result.Should().Be(values);
    }

    [Test]
    public async Task TupleTask10()
    {
        var values = (Int(), Int(), Int(), Int(), Int(), Int(), Int(), Int(), Int(), Int());
        var (v1, v2, v3, v4, v5, v6, v7, v8, v9, v10) = values;
        var result = await (
            Task.FromResult(v1), Task.FromResult(v2),
            Task.FromResult(v3), Task.FromResult(v4),
            Task.FromResult(v5), Task.FromResult(v6),
            Task.FromResult(v7), Task.FromResult(v8),
            Task.FromResult(v9), Task.FromResult(v10)
        );
        result.Should().Be(values);
    }

    public class ConfigureAwait : BaseTest
    {
        [Test]
        public async Task TupleTask()
        {
            var value = Int();
            var task = new ValueTuple<Task<int>>(Task.FromResult(value));
            var result = await task.ConfigureAwait(false);
            result.Should().Be(value);
        }

        [Test]
        public async Task TupleTask2()
        {
            var values = (Int(), Int());
            var (v1, v2) = values;
            var result = await (Task.FromResult(v1), Task.FromResult(v2)).ConfigureAwait(false);
            result.Should().Be(values);
        }

        [Test]
        public async Task TupleTask3()
        {
            var values = (Int(), Int(), Int());
            var (v1, v2, v3) = values;
            var result = await (Task.FromResult(v1), Task.FromResult(v2), Task.FromResult(v3)).ConfigureAwait(false);
            result.Should().Be(values);
        }


        [Test]
        public async Task TupleTask4()
        {
            var values = (Int(), Int(), Int(), Int());
            var (v1, v2, v3, v4) = values;
            var result =
                await (Task.FromResult(v1), Task.FromResult(v2), Task.FromResult(v3), Task.FromResult(v4))
                    .ConfigureAwait(false);
            result.Should().Be(values);
        }


        [Test]
        public async Task TupleTask5()
        {
            var values = (Int(), Int(), Int(), Int(), Int());
            var (v1, v2, v3, v4, v5) = values;
            var result = await (
                Task.FromResult(v1), Task.FromResult(v2),
                Task.FromResult(v3), Task.FromResult(v4),
                Task.FromResult(v5)
            ).ConfigureAwait(false);
            result.Should().Be(values);
        }

        [Test]
        public async Task TupleTask6()
        {
            var values = (Int(), Int(), Int(), Int(), Int(), Int());
            var (v1, v2, v3, v4, v5, v6) = values;
            var result = await (
                Task.FromResult(v1), Task.FromResult(v2),
                Task.FromResult(v3), Task.FromResult(v4),
                Task.FromResult(v5), Task.FromResult(v6)
            ).ConfigureAwait(false);
            result.Should().Be(values);
        }

        [Test]
        public async Task TupleTask7()
        {
            var values = (Int(), Int(), Int(), Int(), Int(), Int(), Int());
            var (v1, v2, v3, v4, v5, v6, v7) = values;
            var result = await (
                Task.FromResult(v1), Task.FromResult(v2),
                Task.FromResult(v3), Task.FromResult(v4),
                Task.FromResult(v5), Task.FromResult(v6),
                Task.FromResult(v7)
            ).ConfigureAwait(false);
            result.Should().Be(values);
        }

        [Test]
        public async Task TupleTask8()
        {
            var values = (Int(), Int(), Int(), Int(), Int(), Int(), Int(), Int());
            var (v1, v2, v3, v4, v5, v6, v7, v8) = values;
            var result = await (
                Task.FromResult(v1), Task.FromResult(v2),
                Task.FromResult(v3), Task.FromResult(v4),
                Task.FromResult(v5), Task.FromResult(v6),
                Task.FromResult(v7), Task.FromResult(v8)
            ).ConfigureAwait(false);
            result.Should().Be(values);
        }

        [Test]
        public async Task TupleTask9()
        {
            var values = (Int(), Int(), Int(), Int(), Int(), Int(), Int(), Int(), Int());
            var (v1, v2, v3, v4, v5, v6, v7, v8, v9) = values;
            var result = await (
                Task.FromResult(v1), Task.FromResult(v2),
                Task.FromResult(v3), Task.FromResult(v4),
                Task.FromResult(v5), Task.FromResult(v6),
                Task.FromResult(v7), Task.FromResult(v8),
                Task.FromResult(v9)
            ).ConfigureAwait(false);
            result.Should().Be(values);
        }

        [Test]
        public async Task TupleTask10()
        {
            var values = (Int(), Int(), Int(), Int(), Int(), Int(), Int(), Int(), Int(), Int());
            var (v1, v2, v3, v4, v5, v6, v7, v8, v9, v10) = values;
            var result = await (
                Task.FromResult(v1), Task.FromResult(v2),
                Task.FromResult(v3), Task.FromResult(v4),
                Task.FromResult(v5), Task.FromResult(v6),
                Task.FromResult(v7), Task.FromResult(v8),
                Task.FromResult(v9), Task.FromResult(v10)
            ).ConfigureAwait(false);
            result.Should().Be(values);
        }
    }
}
