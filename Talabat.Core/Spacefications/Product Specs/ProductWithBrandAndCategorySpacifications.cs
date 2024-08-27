using System.Linq.Expressions;
using Talabat.Core.Entities;

namespace Talabat.Core.Spacefications.Product_Specs;

public class ProductWithBrandAndCategorySpacifications : BaseSpacefications<Product>
{
    public ProductWithBrandAndCategorySpacifications():base()
    {
        ApplyProductSpecs();
    }
    
    public ProductWithBrandAndCategorySpacifications(int id) : base(P=>P.Id==id)
    {
        ApplyProductSpecs();
    }

    private void ApplyProductSpecs()
    {
        Includes.Add(p=>p.Brand);
        Includes.Add(p=>p.Category);
    }
}