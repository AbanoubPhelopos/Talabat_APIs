using Microsoft.EntityFrameworkCore;
using Talabat.Core.Entities;
using Talabat.Core.Repository.Contract;
using Talabat.Core.Spacefications;
using Talabat.Repository.Data;

namespace Talabat.Repository;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    private readonly StoreContext _dbContext;
    public GenericRepository(StoreContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<T?> GetAsync(int Id)
        => await _dbContext.Set<T>().FindAsync(Id);

    public async Task<IEnumerable<T>> GetAllAsync()
        => await _dbContext.Set<T>().ToListAsync();


    public async Task<IEnumerable<T>> GetAllWithSpecAsync(ISpacefications<T> spec)
        => await ApplySpecification(spec).AsNoTracking().ToListAsync();

    public async Task<T?> GetWirhSpec(ISpacefications<T> spec)
        => await ApplySpecification(spec).FirstOrDefaultAsync();

    private IQueryable<T> ApplySpecification(ISpacefications<T> spec)
        => SpaceficationsEvaluator<T>.GetQuery(_dbContext.Set<T>(), spec);
}