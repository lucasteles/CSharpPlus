using System.Linq.Expressions;
using System.Reflection;

namespace CSharpPlus;

/// <summary>
/// Expression Extensions
/// </summary>
public static class ExpressionExtensions
{
    /// <summary>
    /// Get the member info of an expression if it is valid otherwise return default
    /// </summary>
    /// <param name="expression"></param>
    /// <typeparam name="T"></typeparam>
    /// <exception cref="NotImplementedException"></exception>
    public static MemberInfo? GetMemberOrDefault<T>(
        this Expression<T> expression,
        MemberInfo? defaultValue = null) =>
        expression.Body switch
        {
            MemberExpression m => m.Member,
            UnaryExpression { Operand: MemberExpression m } => m.Member,
            _ => defaultValue,
        };

    /// <summary>
    /// Get the member name of an expression if it is valid otherwise return default
    /// </summary>
    /// <param name="expression"></param>
    /// <typeparam name="T"></typeparam>
    /// <exception cref="NotImplementedException"></exception>
    public static string? GetMemberNameOrDefault<T>(
        this Expression<T> expression,
        string? defaultValue = null) =>
        expression.GetMemberOrDefault()?.Name ?? defaultValue;

    /// <summary>
    /// Get the member name of an expression
    /// </summary>
    /// <param name="expression"></param>
    /// <typeparam name="T"></typeparam>
    /// <exception cref="InvalidOperationException"></exception>
    public static string GetMemberName<T>(this Expression<T> expression) =>
        expression.GetMemberNameOrDefault() ??
        throw new InvalidOperationException(expression.GetType().ToString());
}
