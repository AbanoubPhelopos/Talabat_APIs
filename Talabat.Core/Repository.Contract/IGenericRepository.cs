using Talabat.Core.Entities;

namespace Talabat.Core.Repository.Contract;

public interface IGenericRepository<T> where T : BaseEntity
{
    Task<T?> Get(int Id);
    Task<IEnumerable<T>> GetAll();
}