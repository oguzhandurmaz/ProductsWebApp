using Microsoft.EntityFrameworkCore;
using ProductService.Models;

namespace ProductService.Data
{
    public static class PreparationDb
    {
        public static void PrepPopulation(IApplicationBuilder app, bool IsProd)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>(), IsProd);
            }
        }
        private static void SeedData(AppDbContext context, bool IsProd)
        {
            if (IsProd)
            {
                try
                {
                    context.Database.Migrate();
                    Console.WriteLine("--> Migration successfull");

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"--> Migration error {ex.Message}");
                }
            }
            if (!context.Products.Any())
            {
                var category = new Category() { Name = "Teknoloji" };
                context.Categories.Add(category);
                var category2 = new Category() { Name = "Kitap" };
                context.Categories.Add(category2);
                context.SaveChanges();
                context.Products.AddRange(
                    new Product() { Name = "Product1", Description = "Description1", ListPrice = 10M, CreateDate = DateTime.Now,CategoryId = category.Id },
                    new Product() { Name = "Product2", Description = "Description2", ListPrice = 15M, CreateDate = DateTime.Now, CategoryId = category2.Id },
                    new Product() { Name = "Product3", Description = "Description3", ListPrice = 20M, CreateDate = DateTime.Now, CategoryId = category.Id }
                    );
                context.SaveChanges();
            }
        }
    }
}
