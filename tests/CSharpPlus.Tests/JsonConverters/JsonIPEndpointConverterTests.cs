using System.Net;
using CSharpPlus.JsonConverters;

namespace CSharpPlus.Tests.JsonConverters;

using System.Text.Json;
using static System.Text.Json.JsonSerializer;

public class JsonIPEndpointConverterTests : BaseTest
{
    readonly JsonSerializerOptions options = new()
    {
        Converters =
        {
            new JsonIPEndPointConverter(),
        },
    };

    record TestType(IPEndPoint Data);

    [Test]
    public void ShouldParseIPv4()
    {
        var expected = faker.Internet.IpEndPoint();
        var value = Deserialize<TestType>($$"""{"Data": "{{expected}}"}""", options);
        value!.Data.Should().Be(expected);
    }

    [Test]
    public void ShouldParseIPv6()
    {
        var expected = faker.Internet.Ipv6EndPoint();
        var value = Deserialize<TestType>($$"""{"Data": "{{expected}}"}""", options);
        value!.Data.Should().Be(expected);
    }

    [Test]
    public void ShouldSerializeIPv4()
    {
        var value = faker.Internet.IpEndPoint();
        var result = Serialize(new TestType(value), options);
        var expected = $$"""{"Data":"{{value}}"}""";
        result.Should().Be(expected);
    }

    [Test]
    public void ShouldSerializeIPv6()
    {
        var value = faker.Internet.Ipv6EndPoint();
        var result = Serialize(new TestType(value), options);
        var expected = $$"""{"Data":"{{value}}"}""";
        result.Should().Be(expected);
    }
}
