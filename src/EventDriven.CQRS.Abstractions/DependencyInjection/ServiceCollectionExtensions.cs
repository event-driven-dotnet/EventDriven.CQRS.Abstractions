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
                    .WithSingletonLifetime()
                    .AddClasses(classes => classes.AssignableTo(typeof(IQueryHandler<,>)))
                    .AsSelfWithInterfaces()
                    .WithSingletonLifetime();
            });

    /// <summary>
    /// Register command and query handlers from the assemblies that contain the specified types.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the service to.</param>
    /// <param name="lifetime">Service lifetime.</param>
    /// <param name="assemblyMarkerTypes">Assembly marker types.</param>
    /// <returns>A reference to this instance after the operation has completed.</returns>
    public static IServiceCollection AddHandlers(this IServiceCollection services, 
        ServiceLifetime lifetime, params Type[] assemblyMarkerTypes)
    {
        services.AddMediatR(assemblyMarkerTypes);
        switch (lifetime)
        {
            case ServiceLifetime.Scoped:
                services
                    .AddScoped<ICommandBroker, CommandBroker>()
                    .AddScoped<IQueryBroker, QueryBroker>();
                break;
            case ServiceLifetime.Transient:
                return services
                    .AddTransient<ICommandBroker, CommandBroker>()
                    .AddTransient<IQueryBroker, QueryBroker>();
            default:
                return services
                    .AddSingleton<ICommandBroker, CommandBroker>()
                    .AddSingleton<IQueryBroker, QueryBroker>();
        }
        services.Scan(scan =>
        {
            scan.FromAssembliesOf(assemblyMarkerTypes)
                .AddClasses(classes => classes.AssignableTo(typeof(ICommandHandler<,>)))
                .AsSelfWithInterfaces()
                .WithLifetime(lifetime)
                .AddClasses(classes => classes.AssignableTo(typeof(IQueryHandler<,>)))
                .AsSelfWithInterfaces()
                .WithLifetime(lifetime);
        });
        return services;
    }
}