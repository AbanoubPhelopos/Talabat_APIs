using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Talabat.APIs.Dtos;
using Talabat.Core.Entities;
using Talabat.Core.Repository.Contract;
using Talabat.Core.Spacefications.Product_Specs;

namespace Talabat.APIs.Controllers;

public class ProductController : BaseApiController
{
    private readonly IGenericRepository<Product> _productRepo;
    private readonly IMapper _mapper;

    public ProductController(IGenericRepository<Product> productRepo,IMapper mapper)
    {
        _productRepo = productRepo;
        _mapper = mapper;
    }
    [HttpGet()]
    public async Task<ActionResult<IEnumerable<ProductToReturnDto>>> GetProducts()
    {
        ProductWithBrandAndCategorySpacifications spec = new();
        var products =await _productRepo.GetAllWithSpecAsync(spec);
        
        return Ok(_mapper.Map<IEnumerable<Product>,IEnumerable<ProductToReturnDto>>(products));
    }
    [HttpGet("{Id}")]
    public async Task<ActionResult<ProductToReturnDto>> GetProduct(int Id)
    {
        ProductWithBrandAndCategorySpacifications spec = new(Id);

        var product = await _productRepo.GetWirhSpecAsync(spec);
        if (product is null)
            return NotFound(new { Messege = "Not Found", StatusCode = 404 });
        
        return Ok(_mapper.Map<Product,ProductToReturnDto>(product));
    }
}