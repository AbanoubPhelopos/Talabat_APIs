using System.Linq.Expressions;
using Talabat.Core.Entities;

namespace Talabat.Core.Spacefications;

public interface ISpacefications<T> where T : BaseEntity
{
    public Expression<Func<T,bool>>? Criteria { get; set; }
    public List<Expression<Func<T, BaseEntity>>> Includes { get; set; }
    
}