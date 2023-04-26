using System;
using System.Linq.Expressions;

namespace CSharpPlus;

/// <summary>
/// Expression Extensions
/// </summary>
public static class ExpressionExtensions
{
    /// <summary>
    /// Get the member name of an expression if it is valid otherwise return null
    /// </summary>
    /// <param name="expression"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public static string? GetMemberNameOrNull<T>(this Expression<T> expression) =>
        expression.Body switch
        {
            MemberExpression m => m.Member.Name,
            UnaryExpression { Operand: MemberExpression m } => m.Member.Name,
            _ => null,
        };

    /// <summary>
    /// Get the member name of an expression
    /// </summary>
    /// <param name="expression"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public static string GetMemberName<T>(this Expression<T> expression) =>
        expression.GetMemberNameOrNull() ??
        throw new NotImplementedException(expression.GetType().ToString());
}
