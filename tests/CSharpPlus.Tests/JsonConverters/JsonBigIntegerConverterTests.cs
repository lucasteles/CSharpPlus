using System.Numerics;
using CSharpPlus.JsonConverters;

namespace CSharpPlus.Tests.JsonConverters;

using System.Text.Json;
using static System.Text.Json.JsonSerializer;

public class JsonBigIntegerConverterTests : BaseTest
{
    readonly JsonSerializerOptions options = new()
    {
        Converters =
        {
            new JsonBigIntegerConverter(),
        },
    };

    record TestType(BigInteger Data);

    [Test]
    public void ShouldParseLong()
    {
        var expected = faker.Random.Long();
        var value = Deserialize<TestType>($$"""{"Data": "{{expected}}"}""", options)!.Data;

        value.Should().Be(expected);
    }

    [Test]
    public void ShouldParseBigNum()
    {
        var bigNum = faker.Random.ReplaceNumbers(new('#', 100));
        var value = Deserialize<TestType>($$"""{"Data": "{{bigNum}}"}""", options)!.Data;

        var expected = BigInteger.Parse(bigNum);
        value.Should().Be(expected);
    }
}
