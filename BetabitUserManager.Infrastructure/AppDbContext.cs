using BetabitUserManager.Domain;
using Microsoft.EntityFrameworkCore;

namespace BetabitUserManager.Infrastructure;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>().HasData
        (
            new User { Id = 100, Name = "Alice", Age = 19 },
            new User { Id = 101, Name = "Bob", Age = 24 },
            new User { Id = 102, Name = "Claire", Age = 37 }
        );
    }
}