namespace BuberBreakfast.Services.Breakfast;

using BuberBreakfast.ServiceError;
using ErrorOr;

public class BreakfastService : IBreakfastService{

    private static Dictionary<Guid, Models.Breakfast> _breakfasts = new();
    public ErrorOr<Created> CreateBreakfast(Models.Breakfast breakfast){
        _breakfasts.Add(breakfast.Id,breakfast);
        return Result.Created;
    }
    public ErrorOr<Models.Breakfast> GetBreakfast(Guid id){
        if(_breakfasts.TryGetValue(id, out var breakfast))
        {
            return _breakfasts[id];
        }
        return Errors.Breakfast.NotFound;
    }
    public ErrorOr<UpsertedBreakfast> Upsert(Models.Breakfast breakfast){
        var isNewlyCreated = !_breakfasts.ContainsKey(breakfast.Id);
        _breakfasts[breakfast.Id] = breakfast;
        return new UpsertedBreakfast(isNewlyCreated);
    }

    public ErrorOr<Deleted> Delete(Guid id){
        _breakfasts.Remove(id);
        return Result.Deleted;
    }

}
