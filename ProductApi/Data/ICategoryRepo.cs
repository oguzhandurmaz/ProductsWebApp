using ProductService.Models;

namespace ProductService.Data
{
    public interface ICategoryRepo
    {
        /// <summary>
        /// Saves Product Db Changes
        /// </summary>
        /// <returns>if there is any effected item, true else false</returns>
        bool SaveChanges();
        IEnumerable<Category> GetAll();
        Category? GetCategoryById(int id);
        void CreateCategory(Category category);

    }
}
