using System.Linq.Expressions;
using Talabat.Core.Entities;

namespace Talabat.Core.Spacefications;

public class BaseSpacefications<T> :ISpacefications<T> where T : BaseEntity
{
    public Expression<Func<T, bool>>? Criteria { get; set; } = null!;
    public List<Expression<Func<T, BaseEntity>>> Includes { get; set; } = new();

    public BaseSpacefications(Expression<Func<T, bool>> criteriaSpec)
    {
        Criteria = criteriaSpec;
    }
}