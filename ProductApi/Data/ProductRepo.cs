using Microsoft.EntityFrameworkCore;
using ProductService.Dtos;
using ProductService.Models;

namespace ProductService.Data
{
    public class ProductRepo : IProductRepo
    {
        private readonly AppDbContext _context;

        public ProductRepo(AppDbContext context)
        {
            _context = context;
        }
        public void CreateProduct(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }
            _context.Products.Add(product);
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public IEnumerable<Product> GetProductsByCategoryId(int categoryId)
        {
            return _context.Products.Where(w => w.CategoryId == categoryId).ToList();
        }

        public Product? GetProductById(int id)
        {
            return _context.Products.Include(i => i.Category).FirstOrDefault(f => f.Id == id);
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }

        public IEnumerable<Product> GetProductByQuery(ProductQuery productQuery)
        {
            return _context.Products.
                Where(w => w.Name.Contains(productQuery.Name ?? "") &&
                    (productQuery.CategoryId != 0 ? w.CategoryId == productQuery.CategoryId : true))
                .ToList();
        }
    }
}
