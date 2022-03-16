using MediatR;

namespace EventDriven.CQRS.Abstractions.Queries;

/// <inheritdoc />
public class QueryBroker : IQueryBroker
{
    private readonly IMediator _mediator;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="mediator">Mediator for sending queries to handlers.</param>
    public QueryBroker(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    /// <inheritdoc />
    public async Task<TQueryResult> SendAsync<TQueryResult>(IQuery<TQueryResult> query) =>
        await _mediator.Send(query);
}