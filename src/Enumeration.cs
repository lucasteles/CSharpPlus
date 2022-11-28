using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;

/// <summary>
/// Enum extensions
/// </summary>
public static class Enumeration
{
    static TAttr? GetAttribute<TEnum, TAttr>(this TEnum value)
        where TEnum : Enum
        where TAttr : Attribute =>
        value
            .GetType()
            .GetMember(value.ToString())
            .SelectMany(p => p.GetCustomAttributes(typeof(TAttr), true))
            .FirstOrDefault() as TAttr;

    /// <summary>
    /// Get enum description from EnumMember.Value Attribute
    /// </summary>
    /// <param name="enum"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static string GetEnumMemberValue<T>(this T @enum) where T : Enum =>
        @enum
            .GetAttribute<T, EnumMemberAttribute>() is {Value: { } description}
            ? description
            : @enum.ToString();

    /// <summary>
    /// Get enum description from DescriptionAttribute
    /// </summary>
    /// <param name="enum"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static string GetDescription<T>(this T @enum) where T : Enum => @enum
        .GetAttribute<T, DescriptionAttribute>() is {Description: { } description}
        ? description
        : @enum.ToString();


    static TEnum? GetEnumByString<TEnum>(
        string enumDescription,
        Func<TEnum, string> getString,
        StringComparison comparison = StringComparison.Ordinal)
        where TEnum : struct, Enum =>
        Enum.GetValues<TEnum>()
            .Select(e => (Value: e, Desc: getString(e)))
            .Where(x => string.Equals(x.Desc, enumDescription, comparison))
            .Select(x => x.Value)
            .FirstOrDefault();


    /// <summary>
    /// Return Enum value by description attribute
    /// </summary>
    /// <param name="enumDescription"></param>
    /// <param name="comparison"></param>
    /// <typeparam name="TEnum"></typeparam>
    /// <returns></returns>
    public static TEnum? GetEnumFromDescription<TEnum>(
        string enumDescription,
        StringComparison comparison = StringComparison.Ordinal)
        where TEnum : struct, Enum =>
        GetEnumByString<TEnum>(enumDescription, e => e.GetDescription(), comparison);

    /// <summary>
    /// Return Enum value by EnumMember attribute value
    /// </summary>
    /// <param name="enumDescription"></param>
    /// <param name="comparison"></param>
    /// <typeparam name="TEnum"></typeparam>
    /// <returns></returns>
    public static TEnum? GetEnumFromEnumMemberValue<TEnum>(
        string enumDescription,
        StringComparison comparison = StringComparison.Ordinal)
        where TEnum : struct, Enum =>
        GetEnumByString<TEnum>(enumDescription, e => e.GetEnumMemberValue(), comparison);
}
