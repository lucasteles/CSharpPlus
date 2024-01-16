using System.Numerics;
using System.Text.Json.Serialization;
using CSharpPlus.JsonConverters;

namespace CSharpPlus.Tests.JsonConverters;

using System.Text.Json;
using static System.Text.Json.JsonSerializer;

public class BigIntegerJsonConverterTests : BaseTest
{
    readonly JsonSerializerOptions options = new()
    {
        Converters =
        {
            new BigIntegerJsonConverter()
        }
    };

    record TestDate(BigInteger Data);

    [Test]
    public void ShouldParseLong()
    {
        var expected = faker.Random.Long();
        var value = Deserialize<TestDate>($@"{{""Data"": ""{expected}""}}", options)!.Data;

        value.Should().Be(expected);
    }

    [Test]
    public void ShouldParseBigNum()
    {
        var bigNum = faker.Random.ReplaceNumbers(new('#', 100));
        var value = Deserialize<TestDate>($@"{{""Data"": ""{bigNum}""}}", options)!.Data;

        var expected = BigInteger.Parse(bigNum);
        value.Should().Be(expected);
    }
}
