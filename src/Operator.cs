using System.Diagnostics.Contracts;
using System.Numerics;

#pragma warning disable S4136

namespace CSharpPlus;

public static class Operator
{
    [Pure]
    public static T Identity<T>(T v) => v;

    [Pure]
    public static bool Equals<T>(T a, T b) where T : IEqualityOperators<T, T, bool> => a == b;

    [Pure]
    public static bool NotEquals<T>(T a, T b) where T : IEqualityOperators<T, T, bool> => a != b;

    [Pure]
    public static bool Equatable<T>(T a, T b) where T : IEquatable<T> => a.Equals(b);

    [Pure]
    public static bool NotEquatable<T>(T a, T b) where T : IEquatable<T> => !a.Equals(b);

    [Pure]
    public static bool GreaterThan<T>(T a, T b) where T : IComparisonOperators<T, T, bool> => a > b;

    [Pure]
    public static bool LessThan<T>(T a, T b) where T : IComparisonOperators<T, T, bool> => a < b;

    [Pure]
    public static bool GreaterThanOrEquals<T>(T a, T b)
        where T : IComparisonOperators<T, T, bool> => a >= b;

    [Pure]
    public static bool LessThanOrEquals<T>(T a, T b) where T : IComparisonOperators<T, T, bool> =>
        a <= b;

    [Pure]
    public static T Sum<T>(T a, T b) where T : IAdditionOperators<T, T, T> =>
        a + b;

    [Pure]
    public static T Subtract<T>(T a, T b)
        where T : ISubtractionOperators<T, T, T> => a - b;

    [Pure]
    public static T Multiply<T>(T a, T b)
        where T : IMultiplyOperators<T, T, T> => a * b;

    [Pure]
    public static T Divide<T>(T a, T b)
        where T : IDivisionOperators<T, T, T> => a / b;

    [Pure]
    public static T Increment<T>(T value) where T : IIncrementOperators<T>
    {
        var current = value;
        current++;
        return current;
    }

    [Pure]
    public static T Decrement<T>(T value) where T : IDecrementOperators<T>
    {
        var current = value;
        current--;
        return current;
    }

    [Pure]
    public static Func<T, bool> Equals<T>(T value) where T : IEqualityOperators<T, T, bool> =>
        arg => arg == value;


    [Pure]
    public static Func<T, bool> NotEquals<T>(T value) where T : IEqualityOperators<T, T, bool> =>
        arg => arg != value;

    [Pure]
    public static Func<T, bool> Equatable<T>(T value) where T : IEqualityOperators<T, T, bool> =>
        arg => arg.Equals(value);

    [Pure]
    public static Func<T, bool> NotEquatable<T>(T value)
        where T : IEqualityOperators<T, T, bool> =>
        arg => !arg.Equals(value);

    [Pure]
    public static Func<T, bool> GreaterThan<T>(T value)
        where T : IComparisonOperators<T, T, bool> => arg => arg > value;

    [Pure]
    public static Func<T, bool> LessThan<T>(T value) where T : IComparisonOperators<T, T, bool> =>
        arg => arg < value;

    [Pure]
    public static Func<T, bool> GreaterThanOrEquals<T>(T value)
        where T : IComparisonOperators<T, T, bool> => arg => arg >= value;

    [Pure]
    public static Func<T, bool> LessThanOrEquals<T>(T value)
        where T : IComparisonOperators<T, T, bool> =>
        arg => arg <= value;

    [Pure]
    public static Func<T, T> Sum<T>(T value) where T : IAdditionOperators<T, T, T> => arg =>
        arg + value;

    [Pure]
    public static Func<T, T> SubtractBy<T>(T value)
        where T : ISubtractionOperators<T, T, T> => arg => arg - value;

    [Pure]
    public static Func<T, T> SubtractFrom<T>(T value)
        where T : ISubtractionOperators<T, T, T> => arg => value - arg;

    [Pure]
    public static Func<T, T> Multiply<T>(T value)
        where T : IMultiplyOperators<T, T, T> => arg => arg * value;

    [Pure]
    public static Func<T, T> DivideBy<T>(T value)
        where T : IDivisionOperators<T, T, T> => arg => arg / value;

    [Pure]
    public static Func<T, T> DivideFrom<T>(T value)
        where T : IDivisionOperators<T, T, T> => arg => value / arg;
}
