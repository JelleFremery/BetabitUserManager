using BetabitUserManager.Domain;
using BetabitUserManager.UseCases.Repositories;

namespace BetabitUserManager.Infrastructure;

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(AppDbContext context) : base(context)
    {
    }
}