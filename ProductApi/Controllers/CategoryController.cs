using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductService.Data;
using ProductService.Dtos;
using ProductService.Models;

namespace ProductService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepo _repo;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult<IEnumerable<CategoryReadDto>> GetCategories()
        {
            var categories = _repo.GetAll();
            return Ok(_mapper.Map<IEnumerable<CategoryReadDto>>(categories));
        }
        [HttpGet("{id}",Name = "GetCategoryById")]
        public ActionResult<CategoryReadDto> GetCategoryById(int id )
        {
            var category = _repo.GetCategoryById(id);
            if (category == null) return NotFound();
            return Ok(_mapper.Map<CategoryReadDto>(category));
        }
        [HttpPost]
        public ActionResult<CategoryReadDto> CreateCategory(CategoryCreateDto categoryCreateDto)
        {
            var category = _mapper.Map<Category>(categoryCreateDto);
            _repo.CreateCategory(category);
            _repo.SaveChanges();

            var categoryReadDto = _mapper.Map<CategoryReadDto>(category);
            return CreatedAtRoute(nameof(GetCategoryById), new { Id = categoryReadDto.Id }, categoryReadDto);
        }
    }
}
