using System.Linq;
using BetabitUserManager.API.Controllers.Resources;
using Microsoft.AspNetCore.Mvc;

namespace BetabitUserManager.API.Config;

public static class InvalidModelStateResponseFactory
{
    public static IActionResult ProduceErrorResponse(ActionContext context)
    {
        var errors = context.ModelState
                            .SelectMany(m => m.Value.Errors)
                            .Select(m => m.ErrorMessage)
                            .ToList();

        var response = new ErrorResource(messages: errors);
        return new BadRequestObjectResult(response);
    }
}