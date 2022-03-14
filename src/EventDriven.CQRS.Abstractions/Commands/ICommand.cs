using EventDriven.DDD.Abstractions.Entities;
using MediatR;

namespace EventDriven.CQRS.Abstractions.Commands;

/// <summary>
/// An object that is sent to the domain for a state change which is handled by a command handler.
/// </summary>
public interface ICommand : ICommandBase, IRequest<CommandResult> { }
    
/// <summary>
/// An object that is sent to the domain for a state change which is handled by a command handler.
/// </summary>
/// <typeparam name="TEntity">Entity type.</typeparam>
public interface ICommand<TEntity> : ICommandBase<TEntity>, IRequest<CommandResult<TEntity>>
    where TEntity : Entity { }