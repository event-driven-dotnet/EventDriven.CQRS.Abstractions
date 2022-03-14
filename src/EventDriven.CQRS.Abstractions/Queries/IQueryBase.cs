using EventDriven.DDD.Abstractions.Entities;

namespace EventDriven.CQRS.Abstractions.Queries;

/// <summary>
/// An object that is sent to the domain to retrieve data which is handled by a query handler.
/// </summary>
public interface IQueryBase
{
    /// <summary>
    /// Represents the ID of the entity the query is in reference to.
    /// </summary>
    Guid EntityId { get; }
}

/// <inheritdoc />
public interface IQueryBase<out TEntity> : IQueryBase
    where TEntity : IEntity
{
    /// <summary>
    /// The entity the query is in reference to.
    /// </summary>
    public TEntity Entity { get; }
}