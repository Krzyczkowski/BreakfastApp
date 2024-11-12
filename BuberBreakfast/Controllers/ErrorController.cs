using Microsoft.AspNetCore.Mvc;


namespace BuberBreakfast.Controllers;

[ApiController]
[Route("error")]
public class ErrorController : ControllerBase{
    [Route("")]
    public IActionResult Error(){
        return Problem();
    }
}