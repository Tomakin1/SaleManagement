using SaleManagement.Models;

namespace SaleManagement.Dtos
{
    public class CustomerDetailDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int? Age { get; set; }
        public string? Job { get; set; }
        public string? Address { get; set; }
    }
}
