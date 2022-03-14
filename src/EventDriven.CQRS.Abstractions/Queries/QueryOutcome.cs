namespace EventDriven.CQRS.Abstractions.Queries;

/// <summary>
/// Outcome of a query.
/// </summary>
public enum QueryOutcome
{
    /// <summary>
    /// Only if the query was accepted.
    /// </summary>
    Accepted,

    /// <summary>
    /// If the query was rejected due to a conflict.
    /// </summary>
    Conflict,

    /// <summary>
    /// If the query was invalid due to its parameters.
    /// </summary>
    InvalidQuery,

    /// <summary>
    /// If the query was invalid due to the object state.
    /// </summary>
    InvalidState,

    /// <summary>
    /// Not handled.
    /// </summary>
    NotHandled,

    /// <summary>
    /// Entity was not found.
    /// </summary>
    NotFound
}