using System.Reflection;

namespace CSharpPlus;

/// <summary>
/// Assembly Extensions
/// </summary>
public static class AssemblyExtensions
{
    /// <summary>
    /// Get all non-abstract implementations of T
    /// </summary>
    /// <param name="assembly"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static IEnumerable<Type> GetAllImplementations<T>(this Assembly assembly)
        where T : notnull
    {
        ArgumentNullException.ThrowIfNull(assembly);
        var type = typeof(T);
        return assembly.GetTypes().Where(p =>
            type.IsAssignableFrom(p) && p is
            { IsInterface: false, IsAbstract: false, IsGenericType: false });
    }

    /// <summary>
    /// Instantiate all non-abstract implementations of T with a public parameterless constructor
    /// </summary>
    /// <param name="assembly"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static IEnumerable<T> InstantiateAllImplementations<T>(this Assembly assembly)
        where T : notnull
    {
        ArgumentNullException.ThrowIfNull(assembly);
        return assembly
            .GetAllImplementations<T>()
            .Select(t => t
                .IsValueType
                ? Activator.CreateInstance(t)
                : t.GetConstructor(Type.EmptyTypes)
                    ?.Invoke(Array.Empty<object>()))
            .WhereNotNull()
            .Cast<T>();
    }
}
