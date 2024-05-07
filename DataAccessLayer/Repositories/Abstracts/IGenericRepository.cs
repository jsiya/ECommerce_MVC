using Entities.Abstracts;

namespace DataAccessLayer.Repositories.Abstracts;

public interface IGenericRepository<T> where T: Entity, new()
{
    Task<List<T>> GetAllAsync();
    Task<T?> GetByIdAsync(int id);
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(int id);
    Task SaveChangesAsync();
}