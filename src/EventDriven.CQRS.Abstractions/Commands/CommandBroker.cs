using EventDriven.DDD.Abstractions.Entities;
using MediatR;

namespace EventDriven.CQRS.Abstractions.Commands;

/// <inheritdoc />
public class CommandBroker : ICommandBroker
{
    private readonly IMediator _mediator;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="mediator">Mediator for sending commands to handlers.</param>
    public CommandBroker(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    /// <inheritdoc />
    public async Task<CommandResult> SendAsync(ICommand command)
    {
        try
        {
            return await _mediator.Send(command);
        }
        catch (Exception e)
        {
            return new CommandResult(CommandOutcome.NotHandled,
                new Dictionary<string, string[]>
                {
                    {
                        e.GetType().Name,
                        new[] { e.Message }
                    }
                });
        }
    }

    /// <inheritdoc />
    public async Task<CommandResult<TEntity>> SendAsync<TEntity>(ICommand<TEntity> command)
        where TEntity : Entity
    {
        try
        {
            return await _mediator.Send(command);
        }
        catch (Exception e)
        {
            return new CommandResult<TEntity>(CommandOutcome.NotHandled,
                new Dictionary<string, string[]>
                {
                    {
                        e.GetType().Name,
                        new[] { e.Message }
                    }
                });
        }
    }
}