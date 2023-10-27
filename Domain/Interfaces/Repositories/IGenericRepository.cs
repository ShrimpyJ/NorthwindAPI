namespace Domain.Interfaces;

public interface IGenericRepository<TEntity, TId> where TEntity : class
{
    Task<TId> AddAsync(TEntity entity);
    Task<int> UpdateAsync(TEntity entity);
    Task<int> DeleteAsync(TId id);
    Task<TEntity?> GetByIdAsync(TId id);
    Task<List<TEntity>> GetAllAsync();
}