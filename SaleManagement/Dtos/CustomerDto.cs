namespace SaleManagement.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string Firstname { get; set; } = default!;
        public string Lastname { get; set; } = default!;
        public List<ProductDto> Products { get; set; } = new List<ProductDto>();
        public CustomerDetailDto CustomerDetailDto { get; set; }   
    }
}
