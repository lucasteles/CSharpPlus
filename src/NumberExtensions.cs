using System.Numerics;

namespace CSharpPlus;

/// <summary>
/// Extensions for numerics
/// </summary>
public static class NumberExtensions
{
    /// <summary>
    /// Rounds a value to the nearest integer.
    /// </summary>
    /// <param name="d"></param>
    /// <returns></returns>
    public static T Round<T>(this T d) where T : IFloatingPoint<T> => T.Round(d);

    /// <summary>
    /// Rounds a Decimal value to a specified number of decimal places.
    /// </summary>
    /// <param name="d"></param>
    /// <param name="digits"></param>
    /// <returns></returns>
    public static T Round<T>(this T d, int digits) where T : IFloatingPoint<T> => T.Round(d, digits);

    /// <summary>
    /// Rounds a decimal value to an integer using the specified rounding strategy.
    /// </summary>
    /// <param name="d"></param>
    /// <param name="mode"></param>
    /// <returns></returns>
    public static T Round<T>(this T d, MidpointRounding mode) where T : IFloatingPoint<T> => T.Round(d, mode);

    /// <summary>
    /// Rounds a decimal value to the specified precision using the specified rounding strategy.
    /// </summary>
    /// <param name="d"></param>
    /// <param name="digits"></param>
    /// <param name="mode"></param>
    /// <returns></returns>
    public static T Round<T>(this T d, int digits, MidpointRounding mode) where T : IFloatingPoint<T> =>
        T.Round(d, digits, mode);

    /// <summary>
    /// Returns value clamped to the inclusive range of min and max.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <returns></returns>
    ///
    public static T Clamp<T>(this T value, T min, T max) where T : INumber<T> =>
        T.Clamp(value, min, max);

    /// <summary>
    /// Returns value clamped to min 0
    /// </summary>
    public static T ClampZero<T>(this T value) where T : INumber<T>, IMinMaxValue<T> =>
        T.Clamp(value, T.Zero, T.MaxValue);
}
