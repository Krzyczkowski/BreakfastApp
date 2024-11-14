using BuberBreakfast.Interfaces.Persistence;
using BuberBreakfast.Models;
using BuberBreakfast.ServiceError;
using ErrorOr;
using Microsoft.EntityFrameworkCore;

namespace BuberBreakfast.Persistance.Repository;

public class SqlBreakfastRepository : IBreakfastRepository
{
    private readonly BuberBreakfastDbContext _context;

    public SqlBreakfastRepository(BuberBreakfastDbContext context)
    {
        _context = context;
    }

    public bool Add(Breakfast breakfast)
    {
        _context.Breakfasts.Add(breakfast);
        var res = _context.SaveChanges();
        if(res<=0){
            return false;
        }
        return true;
        
    }

    public Breakfast? GetBreakfastById(Guid id)
    {
        return _context.Breakfasts
            .SingleOrDefault(breakfast => breakfast.Id == id);
    }

    public bool Remove(Guid id)
    {
        Breakfast? breakfast = _context.Breakfasts
            .SingleOrDefault(breakfast => breakfast.Id == id);
        if(breakfast is null) return false;
        _context.Breakfasts.Remove(breakfast);
        var res = _context.SaveChanges();
        if(res<=0) return false;
        return true;
    }

public bool Upsert(Breakfast breakfast)
{
    bool isBreakfastInDb = _context.Breakfasts.Any(b => b.Id == breakfast.Id);

    // if no breakfast in db
    if (!isBreakfastInDb)
    {
        var result = Add(breakfast);
        if (result == false)
        {
            throw new Exception("Failed to add the breakfast to the database.");
        }
        return true;
    } // if breakfast already in db
    else
    {
        _context.Breakfasts.Update(breakfast);
        var result = _context.SaveChanges(); 

        if (result <= 0)
        {
            throw new Exception("Failed to update the breakfast in the database.");
        }
    }
    return false;
}

}