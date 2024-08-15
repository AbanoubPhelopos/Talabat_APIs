using Microsoft.AspNetCore.Mvc;
using Talabat.Core.Entities;
using Talabat.Core.Repository.Contract;

namespace Talabat.APIs.Controllers;

public class ProductController : BaseApiController
{
    private readonly IGenericRepository<Product> _productRepo;

    public ProductController(IGenericRepository<Product> productRepo)
    {
        _productRepo = productRepo;
    }

    public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
    {
        var products =await _productRepo.GetAll();
        
        return Ok(products);
    }
    [HttpGet("{Id}")]
    public async Task<ActionResult<Product>> GetProduct(int Id)
    {
        var product = await _productRepo.Get(Id);
        if (product is null)
            return NotFound(new { Messege = "Not Found", StatusCode = 404 });
        
        return Ok(product);
    }
}