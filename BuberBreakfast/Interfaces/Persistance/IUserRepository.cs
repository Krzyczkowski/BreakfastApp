using BuberBreakfast.Models;

namespace BuberBreakfast.Interfaces.Persistance;

public interface IUserRepository{
    User? GetUserByEmail(string email);
    void Add(User user);
    
}