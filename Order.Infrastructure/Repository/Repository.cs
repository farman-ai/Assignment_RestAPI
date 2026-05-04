using Microsoft.EntityFrameworkCore;
using Order.ApplicationCore.Contracts.Repository;
using Order.Infrastructure.Data;

namespace Order.Infrastructure.Repository;

public class Repository<T> : IRepository<T> where T : class
{
    protected readonly OrderDbContext DbContext;

    public Repository(OrderDbContext dbContext)
    {
        DbContext = dbContext;
    }

    public virtual async Task<T?> GetByIdAsync(int id)
    {
        return await DbContext.Set<T>().FindAsync(id);
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync()
    {
        return await DbContext.Set<T>().ToListAsync();
    }

    public virtual async Task<T> AddAsync(T entity)
    {
        await DbContext.Set<T>().AddAsync(entity);
        await DbContext.SaveChangesAsync();
        return entity;
    }

    public virtual async Task<T?> UpdateAsync(T entity)
    {
        DbContext.Set<T>().Update(entity);
        await DbContext.SaveChangesAsync();
        return entity;
    }

    public virtual async Task<bool> DeleteAsync(int id)
    {
        var entity = await GetByIdAsync(id);
        if (entity == null)
        {
            return false;
        }

        DbContext.Set<T>().Remove(entity);
        await DbContext.SaveChangesAsync();
        return true;
    }
}
