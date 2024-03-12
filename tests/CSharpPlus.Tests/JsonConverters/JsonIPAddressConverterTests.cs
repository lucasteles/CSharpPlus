using System.Net;
using CSharpPlus.JsonConverters;

namespace CSharpPlus.Tests.JsonConverters;

using System.Text.Json;
using static System.Text.Json.JsonSerializer;

public class JsonIPAddressConverterTests : BaseTest
{
    readonly JsonSerializerOptions options = new()
    {
        Converters =
        {
            new JsonIPAddressConverter(),
        },
    };

    record TestType(IPAddress Data);

    [Test]
    public void ShouldParseIPv4()
    {
        var expected = faker.Internet.IpAddress();
        var value = Deserialize<TestType>($$"""{"Data": "{{expected.ToString()}}"}""", options);
        value!.Data.Should().Be(expected);
    }

    [Test]
    public void ShouldParseIPv6()
    {
        var expected = faker.Internet.Ipv6Address();
        var value = Deserialize<TestType>($$"""{"Data": "{{expected.ToString()}}"}""", options);
        value!.Data.Should().Be(expected);
    }

    [Test]
    public void ShouldSerializeIPv4()
    {
        var value = faker.Internet.IpAddress();
        var result = Serialize(new TestType(value), options);
        var expected = $$"""{"Data":"{{value}}"}""";
        result.Should().Be(expected);
    }

    [Test]
    public void ShouldSerializeIPv6()
    {
        var value = faker.Internet.Ipv6Address();
        var result = Serialize(new TestType(value), options);
        var expected = $$"""{"Data":"{{value}}"}""";
        result.Should().Be(expected);
    }
}
