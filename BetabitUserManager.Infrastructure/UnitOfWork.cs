using BetabitUserManager.UseCases.Repositories;

namespace BetabitUserManager.Infrastructure;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public async Task CompleteAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task CompleteAsync(CancellationToken token)
    {
        await _context.SaveChangesAsync(token);
    }
}