namespace BetabitUserManager.UseCases.Repositories;

public interface IRepository<T> where T : class
{
    Task<IEnumerable<T>> ListAsync();
    Task<T> FindByIdAsync(int id);
    Task AddAsync(T entity);
    void Update(T entity);
    void Delete(T entity);
}