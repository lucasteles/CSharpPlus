using System;
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
    public static Result<TOk, TError> Ok<TOk, TError>(TOk result) =>
        Result<TOk, TError>.Ok(result);

    /// <summary>
    /// Represents an OK or a Successful result. The code succeeded with a value of 'T
    /// </summary>
    public static Result<TOk, string> Ok<TOk>(TOk result) =>
        Result<TOk, string>.Ok(result);

    /// <summary>
    /// Represents an Error or a Failure. The code failed with a value of 'TError representing what went wrong.
    /// </summary>
    public static Result<TOk, TError> Error<TOk, TError>(TError error) =>
        Result<TOk, TError>.Error(error);

    /// <summary>
    /// Try run function, catching exceptions as a result error value
    /// </summary>
    public static Result<TOk, Exception> Try<TOk>(Func<TOk> func)
    {
        try
        {
            return func();
        }
        catch (Exception e)
        {
            return e;
        }
    }

    /// <summary>
    /// Try run function, catching exceptions as a result error value
    /// </summary>
    public static async Task<Result<TOk, Exception>> TryAsync<TOk>(Func<Task<TOk>> func)
    {
        try
        {
            return await func();
        }
        catch (Exception e)
        {
            return e;
        }
    }


    /// <summary>
    /// Deconstructs result value into (IsOk, OkValue?, ErrorValue?)
    /// </summary>
    public static void Deconstruct<TOk, TError>(
        this Result<TOk, TError> result,
        out bool success,
        out TOk? ok,
        out TError? error)
        where TOk : struct
        where TError : struct
        => (success, ok, error) = (result.IsOk, result.OkValue, result.ErrorValue);

    /// <summary>
    /// Deconstructs result value into (IsOk, OkValue?, ErrorValue?)
    /// </summary>
    public static void Deconstruct<TOk, TError>(
        this Result<TOk, TError> result,
        out bool success,
        out TOk? ok,
        out TError? error)
        where TOk : class
        where TError : class
        => (success, ok, error) = (result.IsOk, result.OkValue, result.ErrorValue);

    /// <summary>
    /// Deconstructs result value into (IsOk, OkValue?, ErrorValue?)
    /// </summary>
    public static void Deconstruct<TOk, TError>(
        this Result<TOk, TError> result,
        out bool success,
        out TOk? ok,
        out TError? error)
        where TOk : struct
        where TError : class
        => (success, ok, error) = (result.IsOk, result.OkValue, result.ErrorValue);

    /// <summary>
    /// Deconstructs result value into (IsOk, OkValue?, ErrorValue?)
    /// </summary>
    public static void Deconstruct<TOk, TError>(
        this Result<TOk, TError> result,
        out bool success,
        out TOk? ok,
        out TError? error)
        where TOk : class
        where TError : struct
        => (success, ok, error) = (result.IsOk, result.OkValue, result.ErrorValue);

    /// <summary>
    /// Convert value type result to nullable
    /// </summary>
    public static Result<TOk?, TError> AsNullable<TOk, TError>(
        this Result<TOk, TError> result)
        where TOk : struct =>
        result.Select(x => (TOk?)x);


    /// <summary>
    /// Convert result of task into task of result
    /// </summary>
    public static async Task<Result<TOk, TError>> ToTask<TOk, TError>(
        this Result<Task<TOk>, TError> result)
    {
        if (result.IsOk) return await result.OkValue;
        return result.ErrorValue;
    }

    /// <summary>
    /// Convert result of task into task of result
    /// </summary>
    public static async Task<Result<TOk, TError>> ToTask<TOk, TError>(
        this Result<TOk, Task<TError>> result)
    {
        if (result.IsOk) return result.OkValue;
        return await result.ErrorValue;
    }

    /// <summary>
    /// Convert result of task into task of result
    /// </summary>
    public static async Task<Result<TOk, TError>> ToTask<TOk, TError>(
        this Result<Task<TOk>, Task<TError>> result)
    {
        if (result.IsOk) return await result.OkValue;
        return await result.ErrorValue;
    }


    /// <summary>
    /// Convert result of task into task of result
    /// </summary>
    public static Result<IReadOnlyList<TOk>, TError> ToResult<TOk, TError>(
        this IEnumerable<Result<TOk, TError>> results)
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
        this IEnumerable<Result<TOk, TError>> results) =>
        from result in results where result.IsOk select result.OkValue;

    /// <summary>
    /// Return new collection with ok values only
    /// </summary>
    public static IEnumerable<TError> ChooseErrors<TOk, TError>(
        this IEnumerable<Result<TOk, TError>> results) =>
        from result in results where result.IsError select result.ErrorValue;

    /// <summary>
    /// If a result is successful, returns it, otherwise <see langword="null"/>.
    /// </summary>
    /// <returns>Nullable value.</returns>
    public static T? ToNullable<T, TError>(this Result<T, TError> valueResult)
        where T : struct
        =>
            valueResult.IsOk ? valueResult.OkValue : null;

    /// <summary>
    /// Switch the result to process value
    /// </summary>
    public static async Task Switch<TOk, TError>(this Result<TOk, TError> result,
        Func<TOk, Task> ok,
        Func<TError, Task> error)
    {
        if (result.IsOk)
            await ok(result.OkValue);
        else
            await error(result.ErrorValue);
    }

    /// <summary>
    /// Switch the result to process value
    /// </summary>
    public static async Task Switch<TOk, TError>(this Result<TOk, TError> result,
        Func<TOk, Task> ok, Action<TError> error)
    {
        if (result.IsOk)
            await ok(result.OkValue);
        else
            error(result.ErrorValue);
    }

    /// <summary>
    /// Switch the result to process value
    /// </summary>
    public static async Task Switch<TOk, TError>(this Result<TOk, TError> result,
        Action<TOk> ok,
        Func<TError, Task> error)
    {
        if (result.IsOk)
            ok(result.OkValue);
        else
            await error(result.ErrorValue);
    }


    /// <summary>
    /// Run side effect when result is OK
    /// </summary>
    public static Result<TOk, TError> Tap<TOk, TError>(
        this Result<TOk, TError> result, Action<TOk> action)
    {
        if (result.IsOk) action(result.OkValue);
        return result;
    }

    /// <summary>
    /// Run side effect when result is OK
    /// </summary>
    public static async Task<Result<TOk, TError>> Tap<TOk, TError>(
        this Result<TOk, TError> result, Func<TOk, Task> action)
    {
        if (result.IsOk) await action(result.OkValue);
        return result;
    }

    /// <summary>
    /// Match the result to obtain the value
    /// </summary>
    public static async Task<T> Match<TOk, TError, T>(this Result<TOk, TError> result,
        Func<TOk, Task<T>> ok, Func<TError, Task<T>> error) =>
        result.IsOk ? await ok(result.OkValue) : await error(result.ErrorValue);

    /// <summary>
    /// Match the result to obtain the value
    /// </summary>
    public static async Task<T> Match<TOk, TError, T>(this Result<TOk, TError> result,
        Func<TOk, Task<T>> ok,
        Func<TError, T> error) =>
        result.IsOk ? await ok(result.OkValue) : error(result.ErrorValue);

    /// <summary>
    /// Match the result to obtain the value
    /// </summary>
    public static async Task<T>
        Match<TOk, TError, T>(this Result<TOk, TError> result,
            Func<TOk, T> ok,
            Func<TError, Task<T>> error) =>
        result.IsOk ? ok(result.OkValue) : await error(result.ErrorValue);

    /// <summary>
    /// Projects ok result value into a new form.
    /// </summary>e
    public static Task<Result<TMap, TError>> SelectAsync<TOk, TError, TMap>(
        this Result<TOk, TError> result,
        Func<TOk, Task<TMap>> selector
    ) => result.Select(selector).ToTask();

    /// <summary>
    /// Projects ok result value into a new form.
    /// </summary>e
    public static Task<Result<TMapOk, TMapError>> SelectAsync<TOk, TError, TMapOk, TMapError>(
        this Result<TOk, TError> result,
        Func<TOk, Task<TMapOk>> okSelector,
        Func<TError, Task<TMapError>> errorSelector
    ) => result.Select(okSelector, errorSelector).ToTask();

    /// <summary>
    /// Projects ok result value into a new form.
    /// </summary>e
    public static Task<Result<TMapOk, TMapError>> SelectAsync<TOk, TError, TMapOk, TMapError>(
        this Result<TOk, TError> result,
        Func<TOk, TMapOk> okSelector,
        Func<TError, Task<TMapError>> errorSelector
    ) => result.Select(okSelector, errorSelector).ToTask();

    /// <summary>
    /// Projects ok result value into a new form.
    /// </summary>e
    public static Task<Result<TMapOk, TMapError>> SelectAsync<TOk, TError, TMapOk, TMapError>(
        this Result<TOk, TError> result,
        Func<TOk, Task<TMapOk>> okSelector,
        Func<TError, TMapError> errorSelector
    ) => result.Select(okSelector, errorSelector).ToTask();

    /// <summary>
    /// Projects ok result value into a new form.
    /// </summary>e
    public static Task<Result<TOk, TMap>> SelectErrorAsync<TOk, TError, TMap>(
        this Result<TOk, TError> result,
        Func<TError, Task<TMap>> selector
    ) => result.SelectError(selector).ToTask();


    /// <summary>
    /// Projects ok result value into a new flattened form.
    /// </summary>
    public static Task<Result<TMap, TError>> SelectManyAsync<TOk, TError, TMap>(
        this Result<TOk, TError> result,
        Func<TOk, Result<Task<TMap>, TError>> bind) =>
        result.SelectMany(bind).ToTask();

    /// <summary>
    /// Projects ok result value into a new flattened form.
    /// </summary>
    public static Task<Result<TMap, TError>> SelectManyAsync<TOk, TError, TMap>(
        this Result<TOk, TError> result,
        Func<TOk, Result<TMap, Task<TError>>> bind) =>
        result.SelectError(Task.FromResult).SelectMany(bind).ToTask();

    /// <summary>
    /// Projects ok result value into a new flattened form.
    /// </summary>
    public static Task<Result<TMap, TError>> SelectManyAsync<TOk, TError, TMap>(
        this Result<TOk, TError> result,
        Func<TOk, Result<Task<TMap>, Task<TError>>> bind) =>
        result.SelectError(Task.FromResult).SelectMany(bind).ToTask();

    /// <summary>
    /// Projects ok result value into a new flattened form.
    /// </summary>
    public static async Task<Result<TMap, TError>> SelectManyAsync<TOk, TError, TMap>(
        this Result<TOk, TError> result,
        Func<TOk, Task<Result<TMap, TError>>> bind) =>
        result.IsError ? new Result<TMap, TError>(result.ErrorValue) : await bind(result.OkValue);
}
