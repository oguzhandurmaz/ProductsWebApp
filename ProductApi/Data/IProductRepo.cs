using ProductService.Dtos;
using ProductService.Models;

namespace ProductService.Data
{
    public interface IProductRepo
    {
        /// <summary>
        /// Saves Product Db Changes
        /// </summary>
        /// <returns>if there is any effected item, true else false</returns>
        bool SaveChanges();
        /// <summary>
        /// Returns List of all Products
        /// </summary>
        /// <returns>List of all Products</returns>
        IEnumerable<Product> GetAll();
        /// <summary>
        /// Return Product By Id
        /// </summary>
        /// <param name="id">ProductId</param>
        /// <returns>Product By Id</returns>
        Product? GetProductById(int id);
        /// <summary>
        /// Returns Product By Category Id
        /// </summary>
        /// <param name="categoryId">Products' category id</param>
        /// <returns>Product By Category Id</returns>
        IEnumerable<Product> GetProductsByCategoryId(int categoryId);
        /// <summary>
        /// Returns List of Products by CategoryId and Name
        /// </summary>
        /// <param name="productQuery">Product CategoryId and Product Name</param>
        /// <returns>List of Products by CategoryId and Name</returns>
        IEnumerable<Product> GetProductByQuery(ProductQuery productQuery);
        /// <summary>
        /// Creates new product record in db
        /// </summary>
        /// <param name="product">Db Product Item</param>
        void CreateProduct(Product product);

    }
}
