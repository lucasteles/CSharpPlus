namespace CSharpPlus.Tests;

public class ValueTaskTupleTests : BaseTest
{
    [Test]
    public async ValueTask TupleValueTask()
    {
        var value = Int();
        var tasks = ValueTask.FromResult(value);
        var task = new ValueTuple<ValueTask<int>>(tasks);
        var result = await task;
        result.Should().Be(value);
    }

    [Test]
    public async ValueTask TupleValueTask2()
    {
        var values = (Int(), Int());
        var (v1, v2) = values;
        var result = await (ValueTask.FromResult(v1), ValueTask.FromResult(v2));
        result.Should().Be(values);
    }

    [Test]
    public async ValueTask TupleValueTask3()
    {
        var values = (Int(), Int(), Int());
        var (v1, v2, v3) = values;
        var result = await (ValueTask.FromResult(v1), ValueTask.FromResult(v2), ValueTask.FromResult(v3));
        result.Should().Be(values);
    }


    [Test]
    public async ValueTask TupleValueTask4()
    {
        var values = (Int(), Int(), Int(), Int());
        var (v1, v2, v3, v4) = values;
        var result =
            await (ValueTask.FromResult(v1), ValueTask.FromResult(v2), ValueTask.FromResult(v3),
                ValueTask.FromResult(v4));
        result.Should().Be(values);
    }

    [Test]
    public async ValueTask TupleValueTask5()
    {
        var values = (Int(), Int(), Int(), Int(), Int());
        var (v1, v2, v3, v4, v5) = values;
        var result = await (
            ValueTask.FromResult(v1), ValueTask.FromResult(v2),
            ValueTask.FromResult(v3), ValueTask.FromResult(v4),
            ValueTask.FromResult(v5)
        );
        result.Should().Be(values);
    }

    [Test]
    public async ValueTask TupleValueTask6()
    {
        var values = (Int(), Int(), Int(), Int(), Int(), Int());
        var (v1, v2, v3, v4, v5, v6) = values;
        var result = await (
            ValueTask.FromResult(v1), ValueTask.FromResult(v2),
            ValueTask.FromResult(v3), ValueTask.FromResult(v4),
            ValueTask.FromResult(v5), ValueTask.FromResult(v6)
        );
        result.Should().Be(values);
    }

    [Test]
    public async ValueTask TupleValueTask7()
    {
        var values = (Int(), Int(), Int(), Int(), Int(), Int(), Int());
        var (v1, v2, v3, v4, v5, v6, v7) = values;
        var result = await (
            ValueTask.FromResult(v1), ValueTask.FromResult(v2),
            ValueTask.FromResult(v3), ValueTask.FromResult(v4),
            ValueTask.FromResult(v5), ValueTask.FromResult(v6),
            ValueTask.FromResult(v7)
        );
        result.Should().Be(values);
    }

    [Test]
    public async ValueTask TupleValueTask8()
    {
        var values = (Int(), Int(), Int(), Int(), Int(), Int(), Int(), Int());
        var (v1, v2, v3, v4, v5, v6, v7, v8) = values;
        var result = await (
            ValueTask.FromResult(v1), ValueTask.FromResult(v2),
            ValueTask.FromResult(v3), ValueTask.FromResult(v4),
            ValueTask.FromResult(v5), ValueTask.FromResult(v6),
            ValueTask.FromResult(v7), ValueTask.FromResult(v8)
        );
        result.Should().Be(values);
    }

    [Test]
    public async ValueTask TupleValueTask9()
    {
        var values = (Int(), Int(), Int(), Int(), Int(), Int(), Int(), Int(), Int());
        var (v1, v2, v3, v4, v5, v6, v7, v8, v9) = values;
        var result = await (
            ValueTask.FromResult(v1), ValueTask.FromResult(v2),
            ValueTask.FromResult(v3), ValueTask.FromResult(v4),
            ValueTask.FromResult(v5), ValueTask.FromResult(v6),
            ValueTask.FromResult(v7), ValueTask.FromResult(v8),
            ValueTask.FromResult(v9)
        );
        result.Should().Be(values);
    }

    [Test]
    public async ValueTask TupleValueTask10()
    {
        var values = (Int(), Int(), Int(), Int(), Int(), Int(), Int(), Int(), Int(), Int());
        var (v1, v2, v3, v4, v5, v6, v7, v8, v9, v10) = values;
        var result = await (
            ValueTask.FromResult(v1), ValueTask.FromResult(v2),
            ValueTask.FromResult(v3), ValueTask.FromResult(v4),
            ValueTask.FromResult(v5), ValueTask.FromResult(v6),
            ValueTask.FromResult(v7), ValueTask.FromResult(v8),
            ValueTask.FromResult(v9), ValueTask.FromResult(v10)
        );
        result.Should().Be(values);
    }

    public class ConfigureAwait : BaseTest
    {
        [Test]
        public async ValueTask TupleValueTask()
        {
            var value = Int();
            var task = new ValueTuple<ValueTask<int>>(ValueTask.FromResult(value));
            var result = await task.ConfigureAwait(false);
            result.Should().Be(value);
        }

        [Test]
        public async ValueTask TupleValueTask2()
        {
            var values = (Int(), Int());
            var (v1, v2) = values;
            var result = await (ValueTask.FromResult(v1), ValueTask.FromResult(v2)).ConfigureAwait(false);
            result.Should().Be(values);
        }

        [Test]
        public async ValueTask TupleValueTask3()
        {
            var values = (Int(), Int(), Int());
            var (v1, v2, v3) = values;
            var result = await (ValueTask.FromResult(v1), ValueTask.FromResult(v2), ValueTask.FromResult(v3))
                .ConfigureAwait(false);
            result.Should().Be(values);
        }


        [Test]
        public async ValueTask TupleValueTask4()
        {
            var values = (Int(), Int(), Int(), Int());
            var (v1, v2, v3, v4) = values;
            var result =
                await (ValueTask.FromResult(v1), ValueTask.FromResult(v2), ValueTask.FromResult(v3),
                        ValueTask.FromResult(v4))
                    .ConfigureAwait(false);
            result.Should().Be(values);
        }


        [Test]
        public async ValueTask TupleValueTask5()
        {
            var values = (Int(), Int(), Int(), Int(), Int());
            var (v1, v2, v3, v4, v5) = values;
            var result = await (
                ValueTask.FromResult(v1), ValueTask.FromResult(v2),
                ValueTask.FromResult(v3), ValueTask.FromResult(v4),
                ValueTask.FromResult(v5)
            ).ConfigureAwait(false);
            result.Should().Be(values);
        }

        [Test]
        public async ValueTask TupleValueTask6()
        {
            var values = (Int(), Int(), Int(), Int(), Int(), Int());
            var (v1, v2, v3, v4, v5, v6) = values;
            var result = await (
                ValueTask.FromResult(v1), ValueTask.FromResult(v2),
                ValueTask.FromResult(v3), ValueTask.FromResult(v4),
                ValueTask.FromResult(v5), ValueTask.FromResult(v6)
            ).ConfigureAwait(false);
            result.Should().Be(values);
        }

        [Test]
        public async ValueTask TupleValueTask7()
        {
            var values = (Int(), Int(), Int(), Int(), Int(), Int(), Int());
            var (v1, v2, v3, v4, v5, v6, v7) = values;
            var result = await (
                ValueTask.FromResult(v1), ValueTask.FromResult(v2),
                ValueTask.FromResult(v3), ValueTask.FromResult(v4),
                ValueTask.FromResult(v5), ValueTask.FromResult(v6),
                ValueTask.FromResult(v7)
            ).ConfigureAwait(false);
            result.Should().Be(values);
        }

        [Test]
        public async ValueTask TupleValueTask8()
        {
            var values = (Int(), Int(), Int(), Int(), Int(), Int(), Int(), Int());
            var (v1, v2, v3, v4, v5, v6, v7, v8) = values;
            var result = await (
                ValueTask.FromResult(v1), ValueTask.FromResult(v2),
                ValueTask.FromResult(v3), ValueTask.FromResult(v4),
                ValueTask.FromResult(v5), ValueTask.FromResult(v6),
                ValueTask.FromResult(v7), ValueTask.FromResult(v8)
            ).ConfigureAwait(false);
            result.Should().Be(values);
        }

        [Test]
        public async ValueTask TupleValueTask9()
        {
            var values = (Int(), Int(), Int(), Int(), Int(), Int(), Int(), Int(), Int());
            var (v1, v2, v3, v4, v5, v6, v7, v8, v9) = values;
            var result = await (
                ValueTask.FromResult(v1), ValueTask.FromResult(v2),
                ValueTask.FromResult(v3), ValueTask.FromResult(v4),
                ValueTask.FromResult(v5), ValueTask.FromResult(v6),
                ValueTask.FromResult(v7), ValueTask.FromResult(v8),
                ValueTask.FromResult(v9)
            ).ConfigureAwait(false);
            result.Should().Be(values);
        }

        [Test]
        public async ValueTask TupleValueTask10()
        {
            var values = (Int(), Int(), Int(), Int(), Int(), Int(), Int(), Int(), Int(), Int());
            var (v1, v2, v3, v4, v5, v6, v7, v8, v9, v10) = values;
            var result = await (
                ValueTask.FromResult(v1), ValueTask.FromResult(v2),
                ValueTask.FromResult(v3), ValueTask.FromResult(v4),
                ValueTask.FromResult(v5), ValueTask.FromResult(v6),
                ValueTask.FromResult(v7), ValueTask.FromResult(v8),
                ValueTask.FromResult(v9), ValueTask.FromResult(v10)
            ).ConfigureAwait(false);
            result.Should().Be(values);
        }
    }
}
