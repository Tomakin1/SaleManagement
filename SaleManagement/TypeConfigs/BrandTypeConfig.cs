using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaleManagement.Models;
using System.Reflection.Emit;

namespace SaleManagement.TypeConfig
{
    public class BrandTypeConfig : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.Property(b => b.Name).HasMaxLength(50).IsRequired();
            
            builder.HasData(

                new Brand { Id = 1, Name = "Monster" },
                new Brand { Id = 2, Name = "Apple" },
                new Brand { Id = 3, Name = "Sony" },
                new Brand { Id = 4, Name = "Samsung" },
                new Brand { Id = 5, Name = "Logitech" },
                new Brand { Id = 6, Name = "Asus" }
            );
        }
    }
}
