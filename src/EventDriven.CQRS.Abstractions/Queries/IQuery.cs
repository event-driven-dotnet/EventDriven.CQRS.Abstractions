using EventDriven.DDD.Abstractions.Entities;
using MediatR;

namespace EventDriven.CQRS.Abstractions.Queries;

/// <summary>
/// An object that is sent to the domain to retrieve data which is handled by a query handler.
/// </summary>
public interface IQuery : IQueryBase, IRequest<QueryResult> { }
    
/// <summary>
/// An object that is sent to the domain to retrieve data which is handled by a query handler.
/// </summary>
/// <typeparam name="TEntity">Entity type.</typeparam>
public interface IQuery<TEntity> : IQueryBase<TEntity>, IRequest<QueryResult<TEntity>>
    where TEntity : Entity { }