using Microsoft.AspNetCore.Mvc;
using BuberBreakfast.Contracts.Breakfast;
using BuberBreakfast.Models;
using BuberBreakfast.Services.Breakfast;
using ErrorOr;
using Microsoft.AspNetCore.Authorization;
namespace BuberBreakfast.Controllers;

[ApiController]
[Route("breakfasts")]
[Authorize]
public class BreakfastController : ApiController{

    private readonly IBreakfastService _breakfastService;

    public BreakfastController(IBreakfastService breakfastService){
        _breakfastService = breakfastService;
    }

    [HttpPost("")]
    public IActionResult CreateBreakfast(CreateBreakfastRequest request)
    {
       ErrorOr<Breakfast> breakfastCreateResult = Breakfast.Create(
            request.Name,
            request.Description,
            request.StartDateTime,
            request.EndDateTime,
            request.Savory,
            request.Sweet
        );
        if(breakfastCreateResult.IsError){
            return Problem(breakfastCreateResult.Errors);
        }

        var breakfast = breakfastCreateResult.Value;

        ErrorOr<Created> result = _breakfastService.CreateBreakfast(breakfast);
        return result.Match(
            created => CreatedAtGetBreakfast(breakfast),
            errors => Problem(errors)
        );
    }


    [HttpGet("{id:guid}")]
    public IActionResult GetBreakfast(Guid id){
       ErrorOr<Breakfast> getBreakfastResult = _breakfastService.GetBreakfast(id);
        return getBreakfastResult.Match(
            breakfast => Ok(MapBreakFastResponse(breakfast)),
            errors => Problem(errors)
        );
    }
    
    [HttpPut("{id:guid}")]
    public IActionResult UpsertBreakfast(Guid id, UpsertBreakfastRequest request){
        ErrorOr<Breakfast> breakfastCreateResult =Breakfast.Create(
            request.Name,
            request.Description,
            request.StartDateTime,
            request.EndDateTime,
            request.Savory,
            request.Sweet,
            id
        );
        if(breakfastCreateResult.IsError){
            return Problem(breakfastCreateResult.Errors);
        }

        var breakfast = breakfastCreateResult.Value;
        ErrorOr<UpsertedBreakfast> result = _breakfastService.Upsert(breakfast);
        
        // return 201 if breakfast was created
        return result.Match(
            upserted => upserted.isNewlyCreated ? CreatedAtGetBreakfast(breakfast) : NoContent(),
            errors => Problem(errors)
        );
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteBreakfast(Guid id){
        ErrorOr<Deleted> result = _breakfastService.Delete(id);
        if(result.IsError){
            return Problem(result.Errors);
        }
        return result.Match(
        deleted => NoContent(),
        errors => Problem(errors)
        );
    }

    private static BreakfastResponse MapBreakFastResponse(Breakfast breakfast){
        return  new BreakfastResponse(
            breakfast.Id,
            breakfast.Name,
            breakfast.Description,
            breakfast.StartDateTime,
            breakfast.EndDateTime,
            breakfast.LastModifiedDateTime,
            breakfast.Savory.ToList(),
            breakfast.Sweet.ToList()
        );
    }

    private IActionResult CreatedAtGetBreakfast(Breakfast breakfast)
    {
        return CreatedAtAction(
            nameof(GetBreakfast),
            new { id = breakfast.Id },
            MapBreakFastResponse(breakfast)
        );
    }
}