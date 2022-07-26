using EventDriven.DDD.Abstractions.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace EventDriven.CQRS.Abstractions.Commands;

/// <inheritdoc />
public class CommandBroker : ICommandBroker
{
    private readonly IMediator _mediator;
    private readonly ILogger<CommandBroker> _logger;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="mediator">Mediator for sending commands to handlers.</param>
    /// <param name="logger">Logger.</param>
    public CommandBroker(IMediator mediator, ILogger<CommandBroker> logger)
    {
        _mediator = mediator;
        _logger = logger;
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
            _logger.LogError(e, "Handler not registered for {Command}", command.GetType().Name);
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