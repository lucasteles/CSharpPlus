using System;

namespace CSharpPlus.Result;

/// <summary>
/// The exception that is thrown when a invalid explicit cast is made on a result.
/// </summary>
public sealed class ResultInvalidCastException : InvalidOperationException
{
    /// <inheritdoc />
    internal ResultInvalidCastException(string message) : base(message)
    {
    }
}

/// <summary>
/// The exception that is thrown for invalid result values.
/// </summary>
public sealed class ResultInvalidException : InvalidOperationException
{
    /// <inheritdoc />
    internal ResultInvalidException(string message) : base(message)
    {
    }
}
