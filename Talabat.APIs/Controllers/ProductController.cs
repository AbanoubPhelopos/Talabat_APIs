using Microsoft.AspNetCore.Mvc;
using Talabat.Core.Entities;
using Talabat.Core.Repository.Contract;
using Talabat.Core.Spacefications.Product_Specs;

namespace Talabat.APIs.Controllers;

public class ProductController : BaseApiController
{
    private readonly IGenericRepository<Product> _productRepo;

    public ProductController(IGenericRepository<Product> productRepo)
    {
        _productRepo = productRepo;
    }
    [HttpGet()]
    public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
    {
        ProductWithBrandAndCategorySpacifications spec = new();
        var products =await _productRepo.GetAllWithSpecAsync(spec);
        
        return Ok(products);
    }
    [HttpGet("{Id}")]
    public async Task<ActionResult<Product>> GetProduct(int Id)
    {
        ProductWithBrandAndCategorySpacifications spec = new(Id);

        var product = await _productRepo.GetWirhSpecAsync(spec);
        if (product is null)
            return NotFound(new { Messege = "Not Found", StatusCode = 404 });
        
        return Ok(product);
    }
}