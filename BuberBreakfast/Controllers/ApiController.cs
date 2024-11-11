using Microsoft.AspNetCore.Mvc;
using BuberBreakfast.Contracts.Breakfast;
using BuberBreakfast.Models;
using BuberBreakfast.Services.Breakfast;
using ErrorOr;
using BuberBreakfast.ServiceError;
namespace BuberBreakfast.Controllers;

// Implementation of ControllerBase which all project controllers will use,
[ApiController]
[Route("api")]
public class ApiController : ControllerBase
{
    //used in action methods in management of error types
    protected IActionResult Problem(List<Error> errors)
    {
        var firstError = errors[0];
        
        int statusCode = firstError.Type switch
        {
            ErrorType.NotFound => StatusCodes.Status404NotFound,
            ErrorType.Validation => StatusCodes.Status400BadRequest,
            ErrorType.Conflict => StatusCodes.Status409Conflict,
            _ => StatusCodes.Status500InternalServerError
        };

        return Problem(statusCode: statusCode, title: firstError.Description);
    }
}
