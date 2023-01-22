using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProductService.Data;
using ProductService.Dtos;
using ProductService.Models;

namespace ProductService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController: ControllerBase
    {
        private readonly IProductRepo _repo;
        private readonly IMapper _mapper;

        public ProductController(IProductRepo repo,IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProductReadDto>> GetProducts()
        {
            var products = _repo.GetAll();
            return Ok(_mapper.Map<IEnumerable<ProductReadDto>>(products));
        }
        [HttpGet("{id}",Name = "GetProductById")]
        public ActionResult<ProductReadDto> GetProductById(int id)
        {
            var product = _repo.GetProductById(id);
            if (product == null) return NotFound();
            return Ok(_mapper.Map<ProductReadDto>(product));
        }

        [HttpGet]
        [Route("[action]")]
        public ActionResult<IEnumerable<ProductReadDto>> ProductByQuery([FromBody] ProductQuery productQuery)
        {
            var products = _repo.GetProductByQuery(productQuery);
            return Ok(_mapper.Map<List<ProductReadDto>>(products));

        }

        [HttpPost]
        public ActionResult<ProductCreateDto> CreateProduct(ProductCreateDto productCreateDto)
        {
            var product = _mapper.Map<Product>(productCreateDto);
            _repo.CreateProduct(product);
            _repo.SaveChanges();

            var productReadDto = _mapper.Map<ProductReadDto>(product);
            return CreatedAtRoute(nameof(GetProductById), new { Id = productReadDto.Id }, productReadDto);
        }
    }
}
