using Microsoft.AspNetCore.Mvc;
using BuberBreakfast.Contracts.Breakfast;
using BuberBreakfast.Models;
using BuberBreakfast.Services.Breakfast;

namespace BuberBreakfast.Controllers;

[ApiController]
[Route("error")]
public class ErrorController : ControllerBase{
    [Route("")]
    public IActionResult Error(){
        return Problem();
    }
}