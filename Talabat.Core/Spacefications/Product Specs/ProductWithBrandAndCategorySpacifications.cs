using System.Linq.Expressions;
using Talabat.Core.Entities;

namespace Talabat.Core.Spacefications.Product_Specs;

public class ProductWithBrandAndCategorySpacifications : BaseSpacefications<Product>
{
    public ProductWithBrandAndCategorySpacifications():base()
    {
        ApplyProductSpecs();
    }
    
    public ProductWithBrandAndCategorySpacifications(Expression<Func<Product, bool>> criteriaSpec) : base(criteriaSpec)
    {
        ApplyProductSpecs();
    }

    private void ApplyProductSpecs()
    {
        Includes.Add(p=>p.Brand);
        Includes.Add(p=>p.Category);
    }
}