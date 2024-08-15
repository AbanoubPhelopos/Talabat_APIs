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
        return await _dbContext.Set<T>().FindAsync(Id);
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        return await _dbContext.Set<T>().ToListAsync();
    }
}