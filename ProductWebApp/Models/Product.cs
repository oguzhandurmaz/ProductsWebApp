namespace ProductWebApp.Models
{
    public class Product
    {
        public int Id { get; set; }
        //public Guid? IdGuid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal ListPrice { get; set; }
        public int Discount { get; set; }
        public int CategoryId { get; set; }
        //public CategoryReadDto? Category { get; set; }
    }
}
