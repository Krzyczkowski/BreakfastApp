using BuberBreakfast.Models;
using Microsoft.EntityFrameworkCore;

namespace BuberBreakfast.Persistance;

public class BuberBreakfastDbContext : DbContext
{
    public BuberBreakfastDbContext(DbContextOptions<BuberBreakfastDbContext> options)
        : base(options)
    {
    }

    public DbSet<Breakfast> Breakfasts { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;
}