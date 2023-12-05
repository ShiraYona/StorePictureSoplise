
using AutoMapper;
using DTO;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using servies;

namespace project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {

        private readonly IProductServices _product;
        private readonly IMapper _mapper;
        public ProductController(IProductServices _Product, IMapper mapper)
        {
            _product = _Product;
            _mapper = mapper;
        }




        [HttpGet]
       public async Task<ActionResult< IEnumerable<ProductDTO>>> getAllProducts(string? desc, int? minPrice, int? maxPrice, [FromQuery] int?[] categoryIds)
        {
            IEnumerable<Product> products = await _product.getAllProducts(desc, minPrice, maxPrice,
           categoryIds);
            IEnumerable<ProductDTO> productsdto = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(products);
            if (productsdto.Count() == 0)
            {
                return NoContent();
            }
           return Ok(productsdto);
        }
            

            
        

            



    }
}
