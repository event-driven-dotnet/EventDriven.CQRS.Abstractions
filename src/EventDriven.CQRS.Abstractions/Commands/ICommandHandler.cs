using EventDriven.DDD.Abstractions.Entities;
using MediatR;

namespace EventDriven.CQRS.Abstractions.Commands;

/// <summary>
/// Command handler.
/// </summary>
/// <typeparam name="TCommand">Command type.</typeparam>
public interface ICommandHandler<in TCommand> :
    IRequestHandler<TCommand, CommandResult>
    where TCommand : class, ICommand { }

/// <summary>
/// Command handler.
/// </summary>
/// <typeparam name="TCommand">Command type.</typeparam>
/// <typeparam name="TEntity">Entity type.</typeparam>
public interface ICommandHandler<TEntity, in TCommand> :
    IRequestHandler<TCommand, CommandResult<TEntity>>
    where TEntity : Entity
    where TCommand : class, ICommand<TEntity> { }
