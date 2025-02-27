﻿namespace SaleManagement.Models
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;

        public ICollection<Product> Products{ get; set; }
    }
}
