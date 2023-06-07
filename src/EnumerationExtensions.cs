using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;

/// <summary>
/// Enum extensions
/// </summary>
public static class EnumerationExtensions
{
    static object? GetAttribute(Type enumType, Type attributeType, string? value) =>
        value is null || !enumType.IsEnum
            ? null
            : enumType
                .GetMember(value)
                .SelectMany(p => p.GetCustomAttributes(attributeType, true))
                .FirstOrDefault();

    static TAttr? GetAttribute<TEnum, TAttr>(this TEnum value)
        where TEnum : Enum
        where TAttr : Attribute =>
        GetAttribute(value.GetType(), typeof(TAttr), value.ToString()) as TAttr;

    /// <summary>
    /// Get description from EnumMember.Value Attribute
    /// </summary>
    public static string? GetEnumMemberValue(object @enum) =>
        GetAttribute(@enum.GetType(), typeof(EnumMemberAttribute), @enum.ToString()) is
            EnumMemberAttribute
        {
            Value: { } description,
        }
            ? description
            : @enum.ToString();

    /// <summary>
    /// Get enum description from EnumMember.Value Attribute
    /// </summary>
    /// <param name="enum"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static string GetEnumMemberValue<T>(this T @enum) where T : Enum =>
        @enum
            .GetAttribute<T, EnumMemberAttribute>() is { Value: { } description }
            ? description
            : @enum.ToString();

    /// <summary>
    /// Get enum description from DescriptionAttribute
    /// </summary>
    /// <param name="enum"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static string GetDescription<T>(this T @enum) where T : Enum => @enum
        .GetAttribute<T, DescriptionAttribute>() is { Description: { } description }
        ? description
        : @enum.ToString();


    /// <summary>
    /// Get description from DescriptionAttribute
    /// </summary>
    public static string? GetDescription(object @enum) =>
        GetAttribute(@enum.GetType(), typeof(DescriptionAttribute), @enum.ToString()) is
            DescriptionAttribute
        {
            Description: { } description,
        }
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
