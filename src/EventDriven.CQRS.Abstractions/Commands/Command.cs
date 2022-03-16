using EventDriven.DDD.Abstractions.Entities;

namespace EventDriven.CQRS.Abstractions.Commands;

/// <summary>
/// An object that is sent to the domain for a state change which is handled by a command handler.
/// </summary>
/// <param name="EntityId">The id of the entity that this command is about.</param>
/// <param name="EntityETag">A unique id that must change atomically with each store of the entity.</param>
public abstract record Command(Guid EntityId = default, string? EntityETag = null) : ICommand;

/// <summary>
/// An object that is sent to the domain for a state change which is handled by a command handler.
/// </summary>
/// <param name="Entity">The entity that this command is about.</param>
/// <param name="EntityId">The id of the entity that this command is about.</param>
/// <param name="EntityETag">A unique id that must change atomically with each store of the entity.</param>
/// <typeparam name="TEntity">Entity type.</typeparam>
public abstract record Command<TEntity>(TEntity? Entity = null, Guid EntityId = default, string? EntityETag = null) :
    ICommand<TEntity>
    where TEntity : Entity
{
    /// <inheritdoc />
    public Guid EntityId { get; } = Entity?.Id ?? EntityId;

    /// <inheritdoc />
    public string? EntityETag { get; } = Entity?.ETag ?? EntityETag;

    /// <inheritdoc />
    public TEntity? Entity { get; } = Entity;
}