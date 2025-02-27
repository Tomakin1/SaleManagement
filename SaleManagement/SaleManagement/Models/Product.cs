namespace SaleManagement.Models
{
    public class Product
    {

        public int Id { get; set; }

        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public int Stock { get; set; }
        public int Price { get; set; }


        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
    }
}
