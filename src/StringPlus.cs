using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace CSharpPlus;

/// <summary>
/// String extensions
/// </summary>
public static class StringPlus
{
    const string JoinSep = ", ";
    public const string NewLine = "\n";

    /// <summary>
    /// Indicates whether the specified string is null or an empty string ("").
    /// </summary>
    /// <param name="value">The string to test</param>
    /// <returns>true if the value parameter is null or an empty string (""); otherwise, false.</returns>
    [Pure]
    public static bool IsNullOrEmpty([NotNullWhen(false)] this string? value) =>
        string.IsNullOrEmpty(value);

    /// <summary>
    /// Indicates whether a specified string is null, empty, or consists only of white-space characters.
    /// </summary>
    /// <param name="value">The string to test.</param>
    /// <returns> true if the value parameter is null or Empty, or if value consists exclusively of white-space characters.
    /// </returns>
    [Pure]
    public static bool IsNullOrWhiteSpace([NotNullWhen(false)] this string? value) =>
        string.IsNullOrWhiteSpace(value);

    public static string Deduplicate(this string value, string token)
    {
        if (value.IsNullOrWhiteSpace() || token.IsNullOrWhiteSpace()) return value;

        StringBuilder sb = new(value.Length);
        var (i, lastWasToken) = (0, false);
        while (i <= value.Length - token.Length)
        {
            if (value.AsSpan(i, token.Length).SequenceEqual(token))
            {
                if (!lastWasToken)
                    sb.Append(token);

                lastWasToken = true;
                i += token.Length;
            }
            else
            {
                sb.Append(value[i]);
                lastWasToken = false;
                i++;
            }
        }

        sb.Append(value, i, value.Length - i);
        return sb.ToString();
    }

    public static string Concat(this IEnumerable<string> values, string separator = JoinSep) =>
        string.Join(separator, values);

    public static string Concat<T>(this IEnumerable<T> values, string separator = JoinSep) =>
        string.Join(separator, values);

    public static string ConcatLines(this IEnumerable<string> values) => values.Concat(NewLine).Deduplicate(NewLine);

    /// <summary>
    /// Returns a persistent case-insensitive hashcode for the string
    /// </summary>
    [Pure]
    public static uint GetStableHashCode(this string value) => value.AsSpan().GetStableHashCode();

    [Pure]
    public static uint GetStableHashCode(this ReadOnlySpan<char> span)
    {
        if (span.IsEmpty) return 0;

        unchecked
        {
            uint hash1 = 5381;
            uint hash2 = hash1;

            ref var curr = ref MemoryMarshal.GetReference(span);
            ref var last = ref Unsafe.Add(ref curr, span.Length - 1);
            ref var limit = ref Unsafe.Add(ref curr, span.Length);

            while (Unsafe.IsAddressLessThan(ref curr, ref limit))
            {
                if (curr is '\0') break;
                hash1 = ((hash1 << 5) + hash1) ^ char.ToLowerInvariant(curr);

                if (Unsafe.AreSame(ref curr, ref last)) break;

                ref var next = ref Unsafe.Add(ref curr, 1);
                if (next is '\0') break;
                hash2 = ((hash2 << 5) + hash2) ^ char.ToLowerInvariant(next);

                curr = ref Unsafe.Add(ref next, 1);
            }

            return hash1 + (hash2 * 1566083941);
        }
    }

    /// <summary>
    /// Returns a persistent case-sensitive hashcode for the string
    /// </summary>
    [Pure]
    public static uint GetStableHashCodeCaseSensitive(this string value) =>
        value.AsSpan().GetStableHashCodeCaseSensitive();

    [Pure]
    public static uint GetStableHashCodeCaseSensitive(this ReadOnlySpan<char> span)
    {
        if (span.IsEmpty) return 0;

        unchecked
        {
            uint hash1 = 5381;
            uint hash2 = hash1;

            ref var curr = ref MemoryMarshal.GetReference(span);
            ref var last = ref Unsafe.Add(ref curr, span.Length - 1);
            ref var limit = ref Unsafe.Add(ref curr, span.Length);

            while (Unsafe.IsAddressLessThan(ref curr, ref limit))
            {
                if (curr is '\0') break;
                hash1 = ((hash1 << 5) + hash1) ^ curr;

                if (Unsafe.AreSame(ref curr, ref last)) break;

                ref var next = ref Unsafe.Add(ref curr, 1);
                if (next is '\0') break;
                hash2 = ((hash2 << 5) + hash2) ^ next;

                curr = ref Unsafe.Add(ref next, 1);
            }

            return hash1 + (hash2 * 1566083941);
        }
    }
}
