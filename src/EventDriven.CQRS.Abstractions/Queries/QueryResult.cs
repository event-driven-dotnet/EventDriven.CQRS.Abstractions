using EventDriven.DDD.Abstractions.Entities;

namespace EventDriven.CQRS.Abstractions.Queries;

/// <summary>
/// Represents the result of dispatching a query.
/// </summary>
public record QueryResult(
    QueryOutcome Outcome,
    IDictionary<string, string[]>? Errors = null);

/// <summary>
/// Represents the result of dispatching a query.
/// </summary>
public record QueryResult<TEntity> : QueryResult
    where TEntity : Entity
{
    /// <summary>
    /// Entities associated with the result.
    /// </summary>
    public List<TEntity> Entities { get; } = new();

    /// <summary>
    /// Entity associated with the result.
    /// </summary>
    public TEntity? Entity => Entities.FirstOrDefault();

    /// <inheritdoc />
    public QueryResult(
        QueryOutcome outcome,
        params TEntity[] entities) : base(outcome)
    {
        foreach (var entity in entities) Entities.Add(entity);
    }

    /// <inheritdoc />
    public QueryResult(
        QueryOutcome outcome,
        IDictionary<string, string[]> errors,
        params TEntity[] entities) : base(outcome, errors)
    {
        foreach (var entity in entities) Entities.Add(entity);
    }
}