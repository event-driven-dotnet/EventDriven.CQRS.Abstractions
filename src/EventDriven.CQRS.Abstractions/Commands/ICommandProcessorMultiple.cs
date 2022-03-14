using EventDriven.DDD.Abstractions.Events;

namespace EventDriven.CQRS.Abstractions.Commands;

/// <summary>
/// Processes a command by generating multiple domain events.
/// </summary>
/// <typeparam name="TCommand">Command type.</typeparam>
public interface ICommandProcessorMultiple<in TCommand> where TCommand : class, ICommand
{
    /// <summary>
    /// Process specified command by creating multiple domain events.
    /// </summary>
    /// <param name="command">The command to process.</param>
    /// <returns>Domain events resulting from the command.</returns>
    IEnumerable<IDomainEvent> Process(TCommand command);
}