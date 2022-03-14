using EventDriven.DDD.Abstractions.Entities;

namespace EventDriven.CQRS.Abstractions.Queries;

/// <summary>
/// Send queries to be handled by a query handler.
/// </summary>
public interface IQueryBroker
{
    /// <summary>
    /// Send a query to be handled by a query handler.
    /// </summary>
    /// <param name="query">The query.</param>
    /// <returns>The query result.</returns>
    Task<QueryResult> SendAsync(IQuery query);
    
    /// <summary>
    /// Send a query to be handled by a query handler.
    /// </summary>
    /// <param name="query">The query.</param>
    /// <typeparam name="TEntity">Entity type.</typeparam>
    /// <returns>The query result.</returns>
    Task<QueryResult<TEntity>> SendAsync<TEntity>(IQuery<TEntity> query)
        where TEntity : Entity;
}