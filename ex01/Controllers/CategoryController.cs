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
    public class CategoryController : Controller
    {
        private readonly IMapper mapper;
        private readonly ICategoryServices _category;
        public CategoryController(ICategoryServices category, IMapper _mapper)
        {
            _category = category;
            mapper = _mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CtegoryDto>>> GetAllCategory()
        {
            
            IEnumerable< Category> categories  = await _category.GetAllCategory();
            IEnumerable<CtegoryDto> categoryDto = mapper.Map<IEnumerable<Category>, IEnumerable<CtegoryDto>>(categories);
            if (categoryDto.Count() == 0)
            {
                return NoContent();
            }
            return Ok(categoryDto);
        }
    }
}
