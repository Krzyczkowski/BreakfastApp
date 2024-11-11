using BuberBreakfast.Contracts.Breakfast;
using BuberBreakfast.Models;

namespace BuberBreakfast.Services.Breakfast;

public interface IBreakfastService{
    void CreateBreakfast(Models.Breakfast breakfast);
    Models.Breakfast GetBreakfast(Guid id);
    void Upsert(Models.Breakfast breakfast);
    void Delete(Guid id);
}