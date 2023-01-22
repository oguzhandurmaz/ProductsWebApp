using ProductWebApp.Models;

namespace ProductWebApp.Services.ProductService
{
    public interface IProductService
    {
        /// <summary>
        /// Gets All Products From Api
        /// </summary>
        /// <returns>List of Products</returns>
        public Task<IEnumerable<Product>?> GetProducts();
        /// <summary>
        /// Gets Products by queries
        /// </summary>
        /// <param name="productQuery">CategoryId product category id, Name product name</param>
        /// <returns>List of Products</returns>
        public Task<IEnumerable<Product>?> GetProductsByQuery(ProductQuery productQuery);
        /// <summary>
        /// Gets All Categories
        /// </summary>
        /// <returns>List of categories</returns>
        public Task<IEnumerable<Category>?> GetCategories();
    }
}
