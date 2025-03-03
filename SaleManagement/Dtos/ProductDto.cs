using SaleManagement.Models;

namespace SaleManagement.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }

        public int BrandId { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public int Stock { get; set; }
        public int Price { get; set; }


    }
}
