namespace BuberBreakfast.Services.Breakfast;
using BuberBreakfast.Services;
public class BreakfastService : IBreakfastService{

    private static Dictionary<Guid, Models.Breakfast> _breakfasts = new();
    public void CreateBreakfast(Models.Breakfast breakfast){
        _breakfasts.Add(breakfast.Id,breakfast);
    }
    public Models.Breakfast GetBreakfast(Guid id){
        return _breakfasts[id];
    }
    public void Upsert(Models.Breakfast breakfast){
        _breakfasts[breakfast.Id] = breakfast;
    }

    public void Delete(Guid id){
        _breakfasts.Remove(id);
    }

}
