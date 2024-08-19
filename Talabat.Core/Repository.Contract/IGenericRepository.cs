using Talabat.Core.Entities;
using Talabat.Core.Spacefications;

namespace Talabat.Core.Repository.Contract;

public interface IGenericRepository<T> where T : BaseEntity
{
    Task<T?> GetAsync(int Id);
    Task<IEnumerable<T>> GetAllAsync();
    
    Task<T?> GetWirhSpecAsync(ISpacefications<T> spec);
    Task<IEnumerable<T>> GetAllWithSpecAsync(ISpacefications<T> spec);
}