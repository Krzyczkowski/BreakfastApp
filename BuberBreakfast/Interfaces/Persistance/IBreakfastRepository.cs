using BuberBreakfast.Models;
using ErrorOr;
namespace BuberBreakfast.Interfaces.Persistence;
public interface IBreakfastRepository
{
    bool Add(Breakfast breakfast);
    Breakfast? GetBreakfastById(Guid id);
    bool Remove(Guid id);
    bool Upsert(Breakfast breakfast);
}