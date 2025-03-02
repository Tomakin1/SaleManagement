namespace SaleManagement.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Firstname { get; set; } = default!;
        public string Lastname { get; set; } = default!;
        public string Fullname => String.Join(" ", Firstname, Lastname);

        public  ICollection<Product>? Products { get; set; }
        public CustomerDetail? CustomerDetail { get; set; }
    }
}
