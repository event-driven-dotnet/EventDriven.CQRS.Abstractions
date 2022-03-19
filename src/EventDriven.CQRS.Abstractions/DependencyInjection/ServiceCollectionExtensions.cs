using EventDriven.CQRS.Abstractions.Commands;
using EventDriven.CQRS.Abstractions.Queries;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace EventDriven.CQRS.Abstractions.DependencyInjection;

/// <summary>
/// Helper methods for adding sagas to dependency injection.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Register command and query handlers from the assemblies that contain the specified types.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the service to.</param>
    /// <param name="assemblyMarkerTypes">Assembly marker types.</param>
    /// <returns>A reference to this instance after the operation has completed.</returns>
    public static IServiceCollection AddHandlers(this IServiceCollection services, 
        params Type[] assemblyMarkerTypes) => services
            .AddSingleton<ICommandBroker, CommandBroker>()
            .AddSingleton<IQueryBroker, QueryBroker>()
            .AddMediatR(assemblyMarkerTypes)
            .Scan(scan =>
            {
                scan.FromAssembliesOf(assemblyMarkerTypes)
                    .AddClasses(classes => classes.AssignableTo(typeof(ICommandHandler<,>)))
                    .AsSelfWithInterfaces()
                    .WithTransientLifetime()
                    .AddClasses(classes => classes.AssignableTo(typeof(IQueryHandler<,>)))
                    .AsSelfWithInterfaces()
                    .WithTransientLifetime();
            });
}