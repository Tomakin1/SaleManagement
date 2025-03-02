using SaleManagement.Models;

namespace SaleManagement.Dtos
{
    public class BrandDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public ICollection<ProductDto> Products { get; set; } = new List<ProductDto>();
    }
}
