using Microsoft.AspNetCore.Mvc;
using BuberBreakfast.Contracts.Breakfast;
using BuberBreakfast.Models;
using BuberBreakfast.Services.Breakfast;

namespace BuberBreakfast.Controllers;

[ApiController]
[Route("breakfasts")]
public class BreakfastController : ControllerBase{

    private readonly IBreakfastService _breakfastService;

    public BreakfastController(IBreakfastService breakfastService){
        _breakfastService = breakfastService;
    }

    [HttpPost("")]
    public IActionResult CreateBreakfast(CreateBreakfastRequest request){
        var breakfast = new Breakfast(
            Guid.NewGuid(),
            request.Name,
            request.Description,
            request.StartDateTime,
            request.EndDateTime,
            DateTime.UtcNow,
            request.Savory,
            request.Sweet
        );

        _breakfastService.CreateBreakfast(breakfast);

        var response = new BreakfastResponse(
            breakfast.Id,
            breakfast.Name,
            breakfast.Description,
            breakfast.StartDateTime,
            breakfast.EndDateTime,
            breakfast.LastModifiedDateTime,
            breakfast.Savory,
            breakfast.Sweet
        );

        return CreatedAtAction(
            nameof(GetBreakfast),
            new {id = breakfast.Id},
            response
        );
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetBreakfast(Guid id){
        Breakfast breakfast = _breakfastService.GetBreakfast(id);
        var response = new BreakfastResponse(
            breakfast.Id,
            breakfast.Name,
            breakfast.Description,
            breakfast.StartDateTime,
            breakfast.EndDateTime,
            breakfast.LastModifiedDateTime,
            breakfast.Savory,
            breakfast.Sweet
        );
        return Ok(response);
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpsertBreakfast(Guid id, UpsertBreakfastRequest request){
        var breakfast = new Breakfast(
            id,
            request.Name,
            request.Description,
            request.StartDateTime,
            request.EndDateTime,
            DateTime.UtcNow,
            request.Savory,
            request.Sweet
        );
        _breakfastService.Upsert(breakfast);

        // return 201 if breakfast was created
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteBreakfast(Guid id){
        _breakfastService.Delete(id);
        return Ok(id);
    }
}