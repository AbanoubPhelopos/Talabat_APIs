using Microsoft.EntityFrameworkCore;
using Talabat.Core.Entities;
using Talabat.Core.Repository.Contract;
using Talabat.Repository.Data;

namespace Talabat.Repository;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    private readonly StoreContext _dbContext;

    public GenericRepository(StoreContext _dbContext)
    {
        this._dbContext = _dbContext;
    }
    public async Task<T?> Get(int Id)
    {
        if (typeof(T) == typeof(Product))
            return await _dbContext.Set<Product>().Where(p => p.Id == Id)
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .FirstOrDefaultAsync() as T;
        return await _dbContext.Set<T>().FindAsync(Id);
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        if (typeof(T) == typeof(Product))
            return (IEnumerable<T>)await _dbContext.Set<Product>().Include(p => p.Brand)
                .Include(p => p.Category)
                .ToListAsync();
        return await _dbContext.Set<T>().ToListAsync();
    }
}