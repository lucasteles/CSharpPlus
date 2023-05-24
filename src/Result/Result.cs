using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using CSharpPlus.Result.Json;

namespace CSharpPlus.Result;

/// <summary>
/// Helper type for errorValue handling without exceptions.
/// </summary>
[DebuggerDisplay("{DebuggerDisplay(),nq}")]
[System.Text.Json.Serialization.JsonConverter(typeof(ResultJsonConverterFactory))]
public readonly struct Result<TOk, TError> : IEquatable<Result<TOk, TError>>
{
    internal TOk? OkValue { get; }
    internal TError? ErrorValue { get; }

    /// <summary>
    /// Returns true if the result is Ok.
    /// </summary>
    [MemberNotNullWhen(true, nameof(OkValue))]
    [MemberNotNullWhen(false, nameof(ErrorValue))]
    public bool IsOk { get; }

    /// <summary>
    /// Returns true if the result is Error.
    /// </summary>
    [MemberNotNullWhen(false, nameof(OkValue))]
    [MemberNotNullWhen(true, nameof(ErrorValue))]
    public bool IsError => !IsOk;

    /// <summary>
    /// The result value
    /// </summary>
    public object Value => IsOk ? OkValue : ErrorValue;

    /// <summary>
    /// Represents an OK or a Successful result. The code succeeded with a value of 'T
    /// </summary>
    public Result(TOk okValue)
    {
        IsOk = true;
        this.OkValue = okValue;
        this.ErrorValue = default;
    }

    /// <summary>
    /// Represents an Error or a Failure. The code failed with a value of 'TError representing what went wrong.
    /// </summary>
    public Result(TError error)
    {
        IsOk = false;
        this.OkValue = default;
        this.ErrorValue = error;
    }

    /// <summary>
    /// Represents an OK or a Successful result. The code succeeded with a value of 'T
    /// </summary>
    public static Result<TOk, TError> Ok(TOk result) => new(result);

    /// <summary>
    /// Represents an Error or a Failure. The code failed with a value of 'TError representing what went wrong.
    /// </summary>
    public static Result<TOk, TError> Error(TError error) => new(error);

    /// <summary>
    /// Casts an Ok value to Result
    /// </summary>
    public static implicit operator Result<TOk, TError>(TOk value) => new(value);

    /// <summary>
    /// Unsafely casts a Result to Ok value
    /// </summary>
    public static explicit operator TOk(Result<TOk, TError> value) =>
        value.IsOk
            ? value.OkValue
            : throw new InvalidOperationException(
                $"Unable to cast 'Error' result value {value.ErrorValue} of type {typeof(TError).FullName} to type {typeof(TOk).FullName}");

    /// <summary>
    /// Unsafely casts a Result to Error value
    /// </summary>
    public static explicit operator TError(Result<TOk, TError> value) =>
        value.IsError
            ? value.ErrorValue
            : throw new InvalidOperationException(
                $"Unable to cast 'Ok' result value {value.OkValue} of type {typeof(TOk).FullName} to type {typeof(TError).FullName}");

    /// <summary>
    /// Casts an Error value to Result
    /// </summary>
    public static implicit operator Result<TOk, TError>(TError value) => new(value);

    /// <summary>
    /// Compare Results
    /// </summary>
    public static bool operator ==(Result<TOk, TError> left, Result<TOk, TError> right) =>
        left.Equals(right);

    /// <summary>
    /// Compare Results
    /// </summary>
    public static bool operator !=(Result<TOk, TError> left, Result<TOk, TError> right) =>
        !(left == right);

    /// <inheritdoc />
    public bool Equals(Result<TOk, TError> other) =>
        IsOk == other.IsOk &&
        EqualityComparer<TOk?>.Default.Equals(OkValue, other.OkValue) &&
        EqualityComparer<TError?>.Default.Equals(ErrorValue, other.ErrorValue);

    /// <inheritdoc />
    public override bool Equals(object? obj) => obj is Result<TOk, TError> other && Equals(other);

    /// <inheritdoc />
    public override int GetHashCode() => HashCode.Combine(OkValue, ErrorValue, IsOk);

    string DebuggerDisplay() => IsOk ? $"Ok({OkValue})" : $"Error({ErrorValue})";

    /// <inheritdoc />
    public override string? ToString() => IsOk ? OkValue.ToString() : ErrorValue.ToString();

    /// <summary>
    /// Convert the result to an enumerable of length 0 or 1.
    /// </summary>
    /// <returns></returns>
    public IEnumerable<TOk> AsEnumerable()
    {
        if (IsOk)
            yield return OkValue;
    }

    /// <summary>
    /// Convert the result to an array of length 0 or 1.
    /// </summary>
    public TOk[] ToArray() => AsEnumerable().ToArray();

    /// <summary>
    /// Match the result to obtain the value
    /// </summary>
    public T Match<T>(Func<TOk, T> ok, Func<TError, T> error) =>
        IsOk ? ok(this.OkValue) : error(this.ErrorValue);

    /// <summary>
    /// Switch the result to process value
    /// </summary>
    public void Switch(Action<TOk> ok, Action<TError> error)
    {
        if (IsOk)
            ok(this.OkValue);
        else
            error(this.ErrorValue);
    }

    /// <summary>
    /// Attempts to extract value from container if it is present.
    /// </summary>
    /// <param name="value">Extracted value.</param>
    /// <returns><see langword="true"/> if value is present; otherwise, <see langword="false"/>.</returns>
    public bool TryGet([NotNullWhen(true)] out TOk? value)
    {
        value = this.OkValue;
        return IsOk;
    }

    /// <summary>
    /// Attempts to extract value from container if it is present.
    /// </summary>
    /// <param name="value">Extracted value.</param>
    /// <param name="error">Extracted error.</param>
    /// <returns><see langword="true"/> if value is present; otherwise, <see langword="false"/>.</returns>
    public bool TryGet(
        [NotNullWhen(true)] out TOk? value,
        [NotNullWhen(false)] out TError? error
    )
    {
        value = this.OkValue;
        error = this.ErrorValue;
        return IsOk;
    }

    /// <summary>
    /// Projects ok result value into a new form.
    /// </summary>
    public Result<TMap, TError> Select<TMap>(Func<TOk, TMap> selector) => Match(
        ok => new Result<TMap, TError>(selector(ok)),
        error => new(error)
    );

    /// <summary>
    /// Projects ok and error result values into a new form.
    /// </summary>
    public Result<TMapOk, TMapError> Select<TMapOk, TMapError>(
        Func<TOk, TMapOk> okSelector,
        Func<TError, TMapError> errorSelector
    ) => Match(
        ok => new Result<TMapOk, TMapError>(okSelector(ok)),
        error => new(errorSelector(error))
    );

    /// <summary>
    /// Projects error result element into a new form.
    /// </summary>
    public Result<TOk, TMap> SelectError<TMap>(Func<TError, TMap> selector) =>
        Match(
            ok => new Result<TOk, TMap>(ok),
            error => new(selector(error))
        );

    /// <summary>
    /// Projects ok result value into a new flattened form.
    /// </summary>
    public Result<TMap, TError> SelectMany<TMap>(Func<TOk, Result<TMap, TError>> bind) =>
        IsError ? new Result<TMap, TError>(ErrorValue) : bind(OkValue);

    /// <summary>
    /// Projects ok result value into a new flattened form.
    /// </summary>
    public Result<TResult, TError> SelectMany<TMap, TResult>(
        Func<TOk, Result<TMap, TError>> bind,
        Func<TOk, TMap, TResult> project) =>
        SelectMany(a => bind(a).Select(b => project(a, b)));

    /// <summary>
    /// Gets the value of the result if the result is Ok, otherwise returns the specified default value.
    /// </summary>
    public TOk DefaultValue(TOk value) => Match(ok => ok, _ => value);

    /// <summary>
    /// Gets the value of the result if the result is Ok, otherwise evaluates defThunk and returns the result
    /// </summary>
    public TOk DefaultWith(Func<TError, TOk> defThunk) => Match(ok => ok, defThunk);

    /// <summary>
    /// Maps a Result value from a pair of Result values.
    /// </summary>
    public Result<TResult, TError> Zip<TResult, TOther>(
        Result<TOther, TError> other,
        Func<TOk, TOther, TResult> selector)
    {
        if (this.IsError)
            return new Result<TResult, TError>(this.ErrorValue);

        if (other.IsError)
            return new Result<TResult, TError>(other.ErrorValue);

        return new(selector(OkValue, other.OkValue));
    }

    /// <summary>
    /// Creates a Result value from a pair of Result values.
    /// </summary>
    public Result<(TOk, TOther), TError> Zip<TOther>(Result<TOther, TError> other) =>
        Zip(other, (a, b) => (a, b));
}
