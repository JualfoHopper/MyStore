using MyStore.Context;

namespace MyStore.Repositories;

public class GenericRepository<TEntity>(AppDbContext _dbContext) where TEntity : class
{
    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _dbContext.Set<TEntity>().ToListAsync();
    }
    public async Task AddEntity(TEntity entity)
    {
        await _dbContext.Set<TEntity>().AddAsync(entity);
        await _dbContext.SaveChangesAsync();
    }
    public async Task<TEntity?> GetById(int entityId)
    {
        return await _dbContext.Set<TEntity>().FindAsync(entityId);
    }
    public async Task EditEntity(TEntity entity)
    {
         _dbContext.Set<TEntity>().Update(entity);
        await _dbContext.SaveChangesAsync();
    }
    public async Task DeleteEntity(TEntity entity)
    {
        _dbContext.Set<TEntity>().Remove(entity);
        await _dbContext.SaveChangesAsync();
    }

}
