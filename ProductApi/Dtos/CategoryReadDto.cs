using System.ComponentModel.DataAnnotations;

namespace ProductService.Dtos
{
    public class CategoryReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
