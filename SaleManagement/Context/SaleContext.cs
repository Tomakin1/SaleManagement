using Microsoft.EntityFrameworkCore;
using SaleManagement.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SaleManagement.Context
{
    public class SaleContext :DbContext
    {

        public SaleContext(DbContextOptions<SaleContext> options) : base(options)
        {
            
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerDetail> CustomerDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Brand> Brands { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SaleContext).Assembly);
            base.OnModelCreating(modelBuilder);

        }
    }
}
