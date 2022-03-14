using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace EventDriven.CQRS.Abstractions.Commands;

/// <summary>
/// Helper methods for adding sagas to dependency injection.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Registers commands and handlers from the assemblies that contain the specified types.`
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the service to.</param>
    /// <param name="assemblyMarkerTypes">Assembly marker types.</param>
    /// <returns>A reference to this instance after the operation has completed.</returns>
    public static IServiceCollection AddCommands(this IServiceCollection services, 
        params Type[] assemblyMarkerTypes) =>
        services.AddSingleton<ICommandBroker, CommandBroker>()
            .AddMediatR(assemblyMarkerTypes);
}