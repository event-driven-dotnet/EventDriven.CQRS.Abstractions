using EventDriven.DDD.Abstractions.Entities;

namespace EventDriven.CQRS.Abstractions.Commands;

/// <summary>
/// An object that is sent to the domain for a state change which is handled by a command handler.
/// </summary>
public interface ICommandBase
{
    /// <summary>
    /// Represents the ID of the entity the command is in reference to.
    /// </summary>
    Guid EntityId { get; }
}

/// <inheritdoc />
public interface ICommandBase<out TEntity> : ICommandBase
    where TEntity : IEntity
{
    /// <summary>
    /// The entity the command is in reference to.
    /// </summary>
    public TEntity Entity { get; }
}