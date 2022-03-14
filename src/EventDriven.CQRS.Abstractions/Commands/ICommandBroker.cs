using EventDriven.DDD.Abstractions.Entities;

namespace EventDriven.CQRS.Abstractions.Commands;

/// <summary>
/// Send commands to be handled by a command handler.
/// </summary>
public interface ICommandBroker
{
    /// <summary>
    /// Send a command to be handled by a command handler.
    /// </summary>
    /// <param name="command">The command.</param>
    /// <returns>The command result.</returns>
    Task<CommandResult> SendAsync(ICommand command);
    
    /// <summary>
    /// Send a command to be handled by a command handler.
    /// </summary>
    /// <param name="command">The command.</param>
    /// <typeparam name="TEntity">Entity type.</typeparam>
    /// <returns>The command result.</returns>
    Task<CommandResult<TEntity>> SendAsync<TEntity>(ICommand<TEntity> command)
        where TEntity : Entity;
}