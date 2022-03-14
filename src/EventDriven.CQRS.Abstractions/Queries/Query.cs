using EventDriven.DDD.Abstractions.Entities;

namespace EventDriven.CQRS.Abstractions.Queries;

/// <summary>
/// An object that is sent to the domain to retrieve data which is handled by a query handler.
/// </summary>
public abstract record Query(Guid EntityId = default) : IQuery;

/// <summary>
/// An object that is sent to the domain to retrieve data which is handled by a query handler.
/// </summary>
/// <typeparam name="TEntity">Entity type.</typeparam>
public abstract record Query<TEntity>(TEntity Entity) : IQuery<TEntity>
    where TEntity : Entity
{
    /// <inheritdoc />
    public Guid EntityId { get; } = Entity.Id;

    /// <inheritdoc />
    public TEntity Entity { get; } = Entity;
}