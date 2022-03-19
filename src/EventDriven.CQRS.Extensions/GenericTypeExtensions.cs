using EventDriven.CQRS.Abstractions.Commands;
using EventDriven.CQRS.Abstractions.Queries;

namespace EventDriven.CQRS.Extensions;

/// <summary>
/// Generic type extensions.
/// </summary>
public static class GenericTypeExtensions
{
    /// <summary>
    /// Get generic type name.
    /// </summary>
    /// <param name="type">Type.</param>
    /// <returns>Generic type name.</returns>
    public static string GetGenericTypeName(this Type type)
    {
        string typeName;

        if (type.IsGenericType)
        {
            var genericTypes = string.Join(",", type.GetGenericArguments().Select(t => t.Name).ToArray());
            typeName = $"{type.Name.Remove(type.Name.IndexOf('`'))}<{genericTypes}>";
        }
        else
        {
            typeName = type.Name;
        }

        return typeName;
    }

    /// <summary>
    /// Determines whether the <paramref name="givenType"/> is assignable from ICommand.
    /// </summary>
    /// <param name="givenType">Given type.</param>
    /// <returns>True if given type is assignable to ICommand</returns>
    public static bool IsCommandType(this Type? givenType) => 
        givenType.IsAssignableToGenericType(typeof(ICommand))
        || givenType.IsAssignableToGenericType(typeof(ICommand<>));

    /// <summary>
    /// Determines whether the <paramref name="givenType"/> is assignable from IQuery.
    /// </summary>
    /// <param name="givenType">Given type.</param>
    /// <returns>True if given type is assignable to IQuery</returns>
    public static bool IsQueryType(this Type? givenType) => 
        givenType.IsAssignableToGenericType(typeof(IQuery<>));

    /// <summary>
    /// Get generic type name.
    /// </summary>
    /// <param name="object">Object.</param>
    /// <returns>Generic type name.</returns>
    public static string GetGenericTypeName(this object @object) =>
        @object.GetType().GetGenericTypeName();
    
    /// <summary>
    /// Determines whether the <paramref name="genericType"/> is assignable from
    /// <paramref name="givenType"/> taking into account generic definitions.
    /// </summary>
    /// <param name="givenType">Given type.</param>
    /// <param name="genericType">Generic type.</param>
    /// <returns></returns>
    public static bool IsAssignableToGenericType(this Type? givenType, Type? genericType)
    {
        if (givenType == null || genericType == null)
            return false;

        return givenType == genericType 
               || givenType.MapsToGenericTypeDefinition(genericType) 
               || givenType.HasInterfaceThatMapsToGenericTypeDefinition(genericType) 
               || givenType.BaseType.IsAssignableToGenericType(genericType);
    }

    private static bool HasInterfaceThatMapsToGenericTypeDefinition(this Type? givenType, Type? genericType) =>
        givenType != null && givenType
            .GetInterfaces()
            .Where(it => it.IsGenericType)
            .Any(it => it.GetGenericTypeDefinition() == genericType);

    private static bool MapsToGenericTypeDefinition(this Type? givenType, Type? genericType) =>
        givenType != null 
        && genericType != null 
        && genericType.IsGenericTypeDefinition 
        && givenType.IsGenericType 
        && givenType.GetGenericTypeDefinition() == genericType;
}