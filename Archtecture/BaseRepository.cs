using Microsoft.EntityFrameworkCore;

namespace dotNET_Temporal.Archtecture;

public abstract class BaseRepository <T, C>(C context) : IBaseRepository<T>, IDisposable where T : class, new() where C : DbContext
{   
    protected readonly C _context = context;
    protected DbSet<T> _dbSet = context.Set<T>();

    public async Task<bool> Insert(T entity)
    {
        try
        {
            ArgumentNullException.ThrowIfNull(entity);

            await _dbSet.AddAsync(entity);

            return await SaveChanges();
        }
        catch
        {
            return false;
        }
    }

    public async Task<bool> Update(T entity)
    {
        try
        {
            ArgumentNullException.ThrowIfNull(entity);

            _dbSet.Entry(entity).State = EntityState.Modified;
            _dbSet.Update(entity);

            return await SaveChanges();
        }
        catch
        {
            return false;
        }
    }

    public void Dispose()
    {
        _context.Dispose();

        GC.SuppressFinalize(this);
    }

    private async Task<bool> SaveChanges() => Convert.ToBoolean(await _context.SaveChangesAsync());
}

public interface IBaseRepository<T> where T : class
{
    Task<bool> Insert(T entity);
    Task<bool> Update(T entity);
}
