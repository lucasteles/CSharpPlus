using System.Globalization;
using FsCheck;

namespace CSharpPlus.Tests;

public class TryParseTests
{
    [PropertyTest]
    public void TryParseInt(int value) => TryParse.ToInt(value.ToString()).Should().Be(value);

    [PropertyTest]
    public void TryParseDouble(NormalFloat value) =>
        TryParse.ToDouble(value.Item.ToString(CultureInfo.InvariantCulture)).Should().Be(value.Item);

    [PropertyTest]
    public void TryParseFloat(float value)
    {
        if (value is float.NaN or float.NegativeInfinity or float.PositiveInfinity)
            return;
        TryParse.ToFloat(value.ToString(CultureInfo.InvariantCulture)).Should().Be(value);
    }

    [PropertyTest]
    public void TryParseDecimal(decimal value) =>
        TryParse.ToDecimal(value.ToString(CultureInfo.InvariantCulture)).Should().Be(value);

    [PropertyTest]
    public void TryParseGuid(Guid value) => TryParse.ToGuid(value.ToString()).Should().Be(value);

    [PropertyTest]
    public void TryParseDateTime(DateTime value)
    {
        var utc = value.ToUniversalTime();
        TryParse.ToDateTime(utc.ToString(CultureInfo.InvariantCulture)).Should().BeCloseTo(utc, TimeSpan.FromMilliseconds(999));
    }

    [PropertyTest]
    public void TryParseBool(bool value) =>
        TryParse.ToBool(value.ToString()).Should().Be(value);

    [PropertyTest]
    public void TryParseByte(byte value) =>
        TryParse.ToByte(value.ToString()).Should().Be(value);

    [PropertyTest]
    public void TryParseLong(long value) =>
        TryParse.ToLong(value.ToString()).Should().Be(value);

    [PropertyTest]
    public void TryParseLong(short value) =>
        TryParse.ToShort(value.ToString()).Should().Be(value);
}
