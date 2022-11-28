using System;

/// <summary>
/// Extensions for numerics
/// </summary>
public static class NumberExtensions
{
    /// <summary>
    /// Rounds a decimal value to the nearest integer.
    /// </summary>
    /// <param name="d"></param>
    /// <returns></returns>
    public static decimal Round(this decimal d) => decimal.Round(d);

    /// <summary>
    /// Rounds a Decimal value to a specified number of decimal places.
    /// </summary>
    /// <param name="d"></param>
    /// <param name="decimals"></param>
    /// <returns></returns>
    public static decimal Round(this decimal d, int decimals) => decimal.Round(d, decimals);

    /// <summary>
    /// Rounds a decimal value to an integer using the specified rounding strategy.
    /// </summary>
    /// <param name="d"></param>
    /// <param name="mode"></param>
    /// <returns></returns>
    public static decimal Round(this decimal d, MidpointRounding mode) => decimal.Round(d, mode);


    /// <summary>
    /// Rounds a decimal value to the specified precision using the specified rounding strategy.
    /// </summary>
    /// <param name="d"></param>
    /// <param name="decimals"></param>
    /// <param name="mode"></param>
    /// <returns></returns>
    public static decimal Round(this decimal d, int decimals, MidpointRounding mode) =>
        decimal.Round(d, decimals, mode);


    /// <summary>
    /// Rounds a double-precision floating-point value to the nearest integral value, and rounds midpoint values to the nearest even number.
    /// </summary>
    /// <param name="d"></param>
    /// <returns></returns>
    public static double Round(this double d) => Math.Round(d);

    /// <summary>
    /// Rounds a double-precision floating-point value to a specified number of fractional digits, and rounds midpoint values to the nearest even number.
    /// </summary>
    /// <param name="d"></param>
    /// <param name="decimals"></param>
    /// <returns></returns>
    public static double Round(this double d, int decimals) => Math.Round(d, decimals);

    /// <summary>
    /// Rounds a double-precision floating-point value to an integer using the specified rounding convention.
    /// </summary>
    /// <param name="d"></param>
    /// <param name="mode"></param>
    /// <returns></returns>
    public static double Round(this double d, MidpointRounding mode) => Math.Round(d, mode);

    /// <summary>
    /// Rounds a double-precision floating-point value to a specified number of fractional digits using the specified rounding convention
    /// </summary>
    /// <param name="d"></param>
    /// <param name="decimals"></param>
    /// <param name="mode"></param>
    /// <returns></returns>
    public static double Round(this double d, int decimals, MidpointRounding mode) =>
        Math.Round(d, decimals, mode);


    /// <summary>
    /// Rounds a single-precision floating-point value to the nearest integral value, and rounds midpoint values to the nearest even number.
    /// </summary>
    /// <param name="d"></param>
    /// <returns></returns>
    public static float Round(this float d) => MathF.Round(d);

    /// <summary>
    /// Rounds a single-precision floating-point value to a specified number of fractional digits, and rounds midpoint values to the nearest even number.
    /// </summary>
    /// <param name="d"></param>
    /// <param name="decimals"></param>
    /// <returns></returns>
    public static float Round(this float d, int decimals) => MathF.Round(d, decimals);

    /// <summary>
    /// Rounds a single-precision floating-point value to an integer using the specified rounding convention.
    /// </summary>
    /// <param name="d"></param>
    /// <param name="mode"></param>
    /// <returns></returns>
    public static float Round(this float d, MidpointRounding mode) => MathF.Round(d, mode);

    /// <summary>
    /// Rounds a single-precision floating-point value to a specified number of fractional digits using the specified rounding convention
    /// </summary>
    /// <param name="d"></param>
    /// <param name="decimals"></param>
    /// <param name="mode"></param>
    /// <returns></returns>
    public static float Round(this float d, int decimals, MidpointRounding mode) =>
        MathF.Round(d, decimals, mode);
}
