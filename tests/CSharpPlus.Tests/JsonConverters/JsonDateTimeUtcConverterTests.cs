using System.Globalization;
using System.Text.Json.Serialization;

namespace CSharpPlus.Tests.JsonConverters;

using System.Text.Json;
using static System.Text.Json.JsonSerializer;

public class JsonDateTimeUtcConverterTests
{
    readonly JsonSerializerOptions options = new()
    {
        Converters =
        {
            new JsonDateTimeUtcConverter(),
        },
    };

    record TestDate(DateTime Data);

    DateTime Parse(string isoDate) =>
        Deserialize<TestDate>($@"{{""Data"": ""{isoDate}""}}", options)!.Data;

    [Test]
    public void ShouldNotChangeOnReadISO8601UtcDate()
    {
        var expected = new DateTime(2022, 07, 2, 10, 30, 20, DateTimeKind.Utc);
        var isoDate = "2022-07-02T10:30:20Z";
        Parse(isoDate).Should().Be(expected)
            .And.Subject!.Value.Kind.Should().Be(DateTimeKind.Utc);
    }

    [Test]
    public void ShouldSetUTCAndNotChangeOnReadISO8601UnspecifiedKindDate()
    {
        var expected = new DateTime(2022, 7, 2, 10, 30, 20, DateTimeKind.Utc);
        var isoDate = "2022-07-02T10:30:20";

        DateTime.Parse(isoDate, DateTimeFormatInfo.InvariantInfo).Kind.Should()
            .Be(DateTimeKind.Unspecified);
        var parsed = Parse(isoDate);
        parsed.Should().Be(expected).And.Subject!.Value.Kind.Should().Be(DateTimeKind.Utc);
    }

    [Test]
    public void ShouldSetUnspecifiedKindUtcConvertingFromTimeZone()
    {
        var expected = new DateTime(2022, 7, 2, 10, 30, 20, DateTimeKind.Utc);
        var isoDate = "2022-07-02T07:30:20";
        DateTime.Parse(isoDate, DateTimeFormatInfo.InvariantInfo).Kind.Should()
            .Be(DateTimeKind.Unspecified);

        var timeZone = TimeZoneInfo.FindSystemTimeZoneById("America/Sao_Paulo");

        var parsed = Deserialize<TestDate>(
            $@"{{""Data"": ""{isoDate}""}}",
            new JsonSerializerOptions
            {
                Converters =
                {
                    new JsonDateTimeUtcConverter(timeZone),
                },
            })!.Data;

        parsed.Should().Be(expected).And.Subject!.Value.Kind.Should().Be(DateTimeKind.Utc);
    }

    [Test]
    public void ShouldSetUnspecifiedKindUtcConvertingFromOffset()
    {
        var expected = new DateTime(2022, 7, 2, 10, 30, 20, DateTimeKind.Utc);
        var isoDate = "2022-07-02T13:30:20";
        DateTime.Parse(isoDate, DateTimeFormatInfo.InvariantInfo).Kind.Should()
            .Be(DateTimeKind.Unspecified);

        var offset = TimeSpan.FromHours(3);

        var parsed = Deserialize<TestDate>(
            $@"{{""Data"": ""{isoDate}""}}",
            new JsonSerializerOptions
            {
                Converters =
                {
                    new JsonDateTimeUtcConverter(offset),
                },
            })!.Data;

        parsed.Should().Be(expected).And.Subject!.Value.Kind.Should().Be(DateTimeKind.Utc);
    }

    [Test]
    public void ShouldChangeLocalDateToUtc()
    {
        var expected = new DateTime(2022, 7, 2, 10, 30, 20, DateTimeKind.Utc);
        var isoDate = "2022-07-02T07:30:20-03:00";

        DateTime.Parse(isoDate, DateTimeFormatInfo.InvariantInfo).Kind.Should()
            .Be(DateTimeKind.Local);
        var parsed = Parse(isoDate);
        parsed.Should().Be(expected).And.Subject!.Value.Kind.Should().Be(DateTimeKind.Utc);
    }
}
