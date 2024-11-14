using BuberBreakfast.Interfaces.Persistance;
using BuberBreakfast.Models;

namespace BuberBreakfast.Persistance;

public class InMemoryUserRepository : IUserRepository{

    private static readonly List<User> _users = new();
    User? IUserRepository.GetUserByEmail(string email)
    {
        return _users.SingleOrDefault(user => user.Email  == email);
    }

    void IUserRepository.Add(User user)
    {
        _users.Add(user);
    }
}