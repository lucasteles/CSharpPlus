using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharpPlus.Result;

/// <summary>
/// Helper type for errorValue handling without exceptions.
/// </summary>
public static class Result
{
    /// <summary>
    /// Represents an OK or a Successful result. The code succeeded with a value of 'T
    /// </summary>
    public static Result<TOk, TError> Ok<TOk, TError>(TOk result) where TError : notnull =>
        Result<TOk, TError>.Ok(result);

    /// <summary>
    /// Represents an OK or a Successful result. The code succeeded with a value of 'T
    /// </summary>
    public static Result<TOk, string> Ok<TOk>(TOk result) =>
        Result<TOk, string>.Ok(result);

    /// <summary>
    /// Represents an Error or a Failure. The code failed with a value of 'TError representing what went wrong.
    /// </summary>
    public static Result<TOk, TError> Error<TOk, TError>(TError error) where TError : notnull =>
        Result<TOk, TError>.Error(error);

    /// <summary>
    /// Deconstructs result value
    /// </summary>
    public static void Deconstruct<TOk, TError>(
        this Result<TOk, TError> result,
        out TOk? ok,
        out TError? error)
        where TOk : struct
        where TError : struct
        => (ok, error) = (result.OkValue, result.ErrorValue);

    /// <summary>
    /// Deconstructs result value
    /// </summary>
    public static void Deconstruct<TOk, TError>(
        this Result<TOk, TError> result,
        out TOk? ok,
        out TError? error)
        where TOk : class
        where TError : class
        => (ok, error) = (result.OkValue, result.ErrorValue);

    /// <summary>
    /// Deconstructs result value
    /// </summary>
    public static void Deconstruct<TOk, TError>(
        this Result<TOk, TError> result,
        out TOk? ok,
        out TError? error)
        where TOk : struct
        where TError : class
        => (ok, error) = (result.OkValue, result.ErrorValue);

    /// <summary>
    /// Deconstructs result value
    /// </summary>
    public static void Deconstruct<TOk, TError>(
        this Result<TOk, TError> result,
        out TOk? ok,
        out TError? error)
        where TOk : class
        where TError : struct
        => (ok, error) = (result.OkValue, result.ErrorValue);

    /// <summary>
    /// Convert result of task into task of result
    /// </summary>
    public static async Task<Result<TOk, TError>> ToTask<TOk, TError>(
        this Result<Task<TOk>, TError> result) where TError : notnull
    {
        if (result.IsOk) return await result.OkValue;
        return result.ErrorValue;
    }

    /// <summary>
    /// Convert result of task into task of result
    /// </summary>
    public static Result<IReadOnlyList<TOk>, TError> ToResult<TOk, TError>(
        this IEnumerable<Result<TOk, TError>> results) where TError : notnull
    {
        List<TOk> okResults = new();
        foreach (var result in results)
        {
            if (result.IsOk)
                okResults.Add(result.OkValue);
            else
                return new(result.ErrorValue);
        }

        return new(okResults.ToReadOnlyList());
    }

    /// <summary>
    /// Return new collection with ok values only
    /// </summary>
    public static IEnumerable<TOk> Choose<TOk, TError>(
        this IEnumerable<Result<TOk, TError>> results) where TError : notnull =>
        from result in results where result.IsOk select result.OkValue;

    /// <summary>
    /// Return new collection with ok values only
    /// </summary>
    public static IEnumerable<TError> ChooseErrors<TOk, TError>(
        this IEnumerable<Result<TOk, TError>> results) where TError : notnull =>
        from result in results where result.IsError select result.ErrorValue;

    /// <summary>
    /// If a result is successful, returns it, otherwise <see langword="null"/>.
    /// </summary>
    /// <returns>Nullable value.</returns>
    public static T? ToNullable<T, TError>(this Result<T, TError> valueResult)
        where T : struct
        where TError : notnull =>
        valueResult.IsOk ? valueResult.OkValue : null;
}
