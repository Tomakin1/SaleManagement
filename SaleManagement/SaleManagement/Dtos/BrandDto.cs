using SaleManagement.Models;

namespace SaleManagement.Dtos
{
    public class BrandDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
