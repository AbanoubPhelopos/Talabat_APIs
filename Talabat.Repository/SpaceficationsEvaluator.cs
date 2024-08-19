using Microsoft.EntityFrameworkCore;
using Talabat.Core.Entities;
using Talabat.Core.Spacefications;

namespace Talabat.Repository;

public static class SpaceficationsEvaluator<TEntity> where TEntity :BaseEntity
{
    public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, ISpacefications<TEntity> spec)
    {
        var query = inputQuery;

        if (spec.Criteria is not null)
            query = query.Where(spec.Criteria);

        query = spec.Includes.Aggregate(query, (currentQuery, IncludeExpression) => currentQuery.Include(IncludeExpression));
        
        return query;
    }
}