using ProductService.Models;
using System.ComponentModel.DataAnnotations;

namespace ProductService.Dtos
{
    public class ProductCreateDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal ListPrice { get; set; }
        [Required]
        public int Discount { get; set; }

        public int? CategoryId { get; set; }
    }
}
