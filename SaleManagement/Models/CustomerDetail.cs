namespace SaleManagement.Models
{
    public class CustomerDetail
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public int? Age { get; set; }
        public string? Job { get; set; }
        public string? Address { get; set; }
    }
}
