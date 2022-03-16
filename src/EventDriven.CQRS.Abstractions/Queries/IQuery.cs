using MediatR;

namespace EventDriven.CQRS.Abstractions.Queries;

/// <summary>
/// An object that is sent to the domain to retrieve data which is handled by a query handler.
/// </summary>
/// <typeparam name="TQueryResult">Query result type.</typeparam>
public interface IQuery<out TQueryResult> : IRequest<TQueryResult> { }