using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaleManagement.Models;
using System.Reflection.Emit;

namespace SaleManagement.TypeConfig
{
    public class CustomerTypeConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Firstname).IsRequired().HasMaxLength(50);
            builder.Property(c => c.Lastname).IsRequired().HasMaxLength(50);

            builder.HasOne(c => c.CustomerDetail).WithOne(c => c.Customer)
            .HasForeignKey<CustomerDetail>(c => c.CustomerId);

            builder.HasMany(c => c.Products).WithOne(p => p.Customer)
            .HasForeignKey(p => p.CustomerId);

            builder.HasData(

                new Customer { Id = 1, Firstname = "Ömer", Lastname = "Tomakin" },
                new Customer { Id = 2, Firstname = "Ahmet", Lastname = "Yılmaz" },
                new Customer { Id = 3, Firstname = "Mehmet", Lastname = "Kaya" },
                new Customer { Id = 4, Firstname = "Ayşe", Lastname = "Demir" },
                new Customer { Id = 5, Firstname = "Fatma", Lastname = "Çelik" },
                new Customer { Id = 6, Firstname = "Ali", Lastname = "Şahin" },
                new Customer { Id = 7, Firstname = "Zeynep", Lastname = "Koç" },
                new Customer { Id = 8, Firstname = "Hasan", Lastname = "Öztürk" },
                new Customer { Id = 9, Firstname = "Elif", Lastname = "Arslan" },
                new Customer { Id = 10, Firstname = "Burak", Lastname = "Güneş" },
                new Customer { Id = 11, Firstname = "Merve", Lastname = "Aydın" },
                new Customer { Id = 12, Firstname = "Emre", Lastname = "Taş" },
                new Customer { Id = 13, Firstname = "Hüseyin", Lastname = "Erdem" },
                new Customer { Id = 14, Firstname = "Büşra", Lastname = "Yıldırım" },
                new Customer { Id = 15, Firstname = "Cem", Lastname = "Karaca" }

            );
        }
    }
}
