using MediatR;

namespace EventDriven.CQRS.Abstractions.Queries;

/// <summary>
/// Query handler.
/// </summary>
/// <typeparam name="TQuery">Query type.</typeparam>
/// <typeparam name="TQueryResult"></typeparam>
public interface IQueryHandler<in TQuery, TQueryResult> :
    IRequestHandler<TQuery, TQueryResult>
    where TQuery : class, IQuery<TQueryResult> { }