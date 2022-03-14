using EventDriven.DDD.Abstractions.Entities;
using MediatR;

namespace EventDriven.CQRS.Abstractions.Queries;

/// <summary>
/// Query handler.
/// </summary>
/// <typeparam name="TQuery">Query type.</typeparam>
public interface IQueryHandler<in TQuery> :
    IRequestHandler<TQuery, QueryResult>
    where TQuery : class, IQuery { }

/// <summary>
/// Query handler.
/// </summary>
/// <typeparam name="TQuery">Query type.</typeparam>
/// <typeparam name="TEntity">Entity type.</typeparam>
public interface IQueryHandler<TEntity, in TQuery> :
    IRequestHandler<TQuery, QueryResult<TEntity>>
    where TEntity : Entity
    where TQuery : class, IQuery<TEntity> { }
