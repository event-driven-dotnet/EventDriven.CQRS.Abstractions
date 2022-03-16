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
    /// <typeparam name="TQueryResult">Query result type.</typeparam>
    /// <returns>The query result.</returns>
    Task<TQueryResult> SendAsync<TQueryResult>(IQuery<TQueryResult> query);
}