namespace BuberBreakfast.Services.Breakfast;

using System.Data;
using BuberBreakfast.Interfaces.Persistence;
using BuberBreakfast.Models;
using BuberBreakfast.ServiceError;
using ErrorOr;

public class BreakfastService : IBreakfastService{
    private readonly IBreakfastRepository _repository; 

    public BreakfastService(IBreakfastRepository repository){
        _repository = repository;
    }

    public ErrorOr<Created> CreateBreakfast(Breakfast breakfast){
        _repository.Add(breakfast);
        return Result.Created;
    }
    public ErrorOr<Breakfast> GetBreakfast(Guid id){
        Breakfast? breakfast = _repository.GetBreakfastById(id);

        if(breakfast is not null)
        {
            return breakfast;
        }
        return Errors.Breakfast.NotFound;
    }
    public ErrorOr<UpsertedBreakfast> Upsert(Breakfast breakfast){
        var isNewlyCreated = _repository.Upsert(breakfast);
        return new UpsertedBreakfast(isNewlyCreated);
    }

    public ErrorOr<Deleted> Delete(Guid id){
        _repository.Remove(id);
        return Result.Deleted;
    }

}
