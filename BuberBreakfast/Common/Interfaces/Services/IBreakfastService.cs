using BuberBreakfast.Contracts.Breakfast;
using BuberBreakfast.Models;
using ErrorOr;

namespace BuberBreakfast.Services.Breakfast;

public interface IBreakfastService{
    ErrorOr<Created> CreateBreakfast(Models.Breakfast breakfast);
    ErrorOr<Models.Breakfast> GetBreakfast(Guid id);
    ErrorOr<UpsertedBreakfast> Upsert(Models.Breakfast breakfast);
    ErrorOr<Deleted> Delete(Guid id);
}