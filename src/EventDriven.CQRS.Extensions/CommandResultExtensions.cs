using EventDriven.CQRS.Abstractions.Commands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventDriven.CQRS.Extensions;

/// <summary>
/// CommandResult extension methods.
/// </summary>
public static class CommandResultExtensions
{
    /// <summary>
    /// Convert CommandResult to an ActionResult.
    /// </summary>
    /// <param name="result">Command result.</param>
    /// <param name="entity">Entity.</param>
    /// <returns>Action result.</returns>
    public static ActionResult ToActionResult(this CommandResult result, object? entity = null)
    {
        switch (result.Outcome)
        {
            case CommandOutcome.Accepted:
                if (entity != null) return new OkObjectResult(entity);
                return new OkResult();
            case CommandOutcome.Conflict:
                return new ConflictResult();
            case CommandOutcome.NotFound:
                return new NotFoundResult();
            default:
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }
    }
}
