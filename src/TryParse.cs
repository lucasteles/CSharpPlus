/// <summary>
/// String Parsers witch return Nullable of T
/// </summary>
public static class TryParse
{
    /// <summary>
    /// Converts the string representation of a number to its 32-bit signed integer equivalent. A return value is the
    /// parsed value if success, null otherwise
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static int? ToInt(string value) => int.TryParse(value, out var result) ? result : null;

    /// <summary>
    /// Converts the string representation of a number to its double-precision floating-point number equivalent.
    /// A non-null return value indicates that the conversion succeeded, null if it failed.
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static double? ToDouble(string value) => double.TryParse(value, out var result) ? result : null;

    /// <summary>
    /// Converts the string representation of a number to its single-precision floating-point number equivalent.
    /// A non-null return value indicates that the conversion succeeded, null if it failed.
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static float? ToFloat(string value) => float.TryParse(value, out var result) ? result : null;

    /// <summary>
    /// Converts the string representation of a number to its Decimal equivalent.
    /// A non-null return value indicates that the conversion succeeded, null if it failed.
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static decimal? ToDecimal(string value) => decimal.TryParse(value, out var result) ? result : null;

    /// <summary>
    /// Converts the string representation of a GUID to the equivalent Guid structure.
    /// A non-null return value indicates that the conversion succeeded, null if it failed.
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static System.Guid? ToGuid(string value) => System.Guid.TryParse(value, out var result) ? result : null;


    /// <summary>
    /// Converts the specified string representation of a date and time to its DateTime equivalent.
    /// A non-null return value indicates that the conversion succeeded, null if it failed.
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static System.DateTime? ToDateTime(string value) =>
        System.DateTime.TryParse(value, out var result) ? result : null;


    /// <summary>
    /// Tries to convert the specified string representation of a logical value to its Boolean equivalent.
    /// A non-null return value indicates that the conversion succeeded, null if it failed.
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static bool? ToBool(string value) => bool.TryParse(value, out var result) ? result : null;

    /// <summary>
    /// Tries to convert the string representation of a number to its Byte equivalent.
    /// A non-null return value indicates that the conversion succeeded, null if it failed.
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static byte? ToByte(string value) => byte.TryParse(value, out var result) ? result : null;

    /// <summary>
    /// Converts the string representation of a number to its 64-bit signed integer equivalent.
    /// A non-null return value indicates that the conversion succeeded, null if it failed.
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static long? ToLong(string value) => long.TryParse(value, out var result) ? result : null;

    /// <summary>
    /// Converts the string representation of a number to its 16-bit signed integer equivalent.
    /// A non-null return value indicates that the conversion succeeded, null if it failed.
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static short? ToShort(string value) => short.TryParse(value, out var result) ? result : null;
}
