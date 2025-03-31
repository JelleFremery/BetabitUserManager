namespace BetabitUserManager.UseCases.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync();
    Task CompleteAsync(CancellationToken token);
}