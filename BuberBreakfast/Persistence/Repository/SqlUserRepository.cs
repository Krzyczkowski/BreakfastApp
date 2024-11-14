using BuberBreakfast.Interfaces.Persistance;
using BuberBreakfast.Models;
using BuberBreakfast.Persistance;

public class SqlUserRepository : IUserRepository
{
    private readonly BuberBreakfastDbContext _context;

    public SqlUserRepository(BuberBreakfastDbContext context)
    {
        _context = context;
    }

    public User? GetUserByEmail(string email)
    {
        return _context.Users.SingleOrDefault(user => user.Email == email);
    }

    public void Add(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
    }
}