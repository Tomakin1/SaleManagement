using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaleManagement.Models;
using System.Reflection.Emit;

namespace SaleManagement.TypeConfig
{
    public class CustomerDetailConfig : IEntityTypeConfiguration<CustomerDetail>
    {
        public void Configure(EntityTypeBuilder<CustomerDetail> builder)
        {

            builder.Property(c => c.Address).HasMaxLength(350).IsRequired(false);
            builder.Property(c => c.Age).IsRequired(false);
            builder.Property(c => c.Job).HasMaxLength(50).IsRequired(false);
            builder.HasData(

                new CustomerDetail { Id = 1, Age = 20, Address = "Çekmeköy/İstanbul", CustomerId = 1, Job = "JR. Backend Developer" },
                new CustomerDetail { Id = 2, Age = 25, Address = "Kadıköy/İstanbul", CustomerId = 2, Job = "Frontend Developer" },
                new CustomerDetail { Id = 3, Age = 30, Address = "Beşiktaş/İstanbul", CustomerId = 3, Job = "Full Stack Developer" },
                new CustomerDetail { Id = 4, Age = 27, Address = "Bakırköy/İstanbul", CustomerId = 4, Job = "UI/UX Designer" },
                new CustomerDetail { Id = 5, Age = 35, Address = "Bornova/İzmir", CustomerId = 5, Job = "Data Scientist" },
                new CustomerDetail { Id = 6, Age = 22, Address = "Keçiören/Ankara", CustomerId = 6, Job = "Software Engineer" },
                new CustomerDetail { Id = 7, Age = 28, Address = "Konak/İzmir", CustomerId = 7, Job = "DevOps Engineer" },
                new CustomerDetail { Id = 8, Age = 33, Address = "Esenyurt/İstanbul", CustomerId = 8, Job = "Cloud Engineer" },
                new CustomerDetail { Id = 9, Age = 24, Address = "Nilüfer/Bursa", CustomerId = 9, Job = "Mobile Developer" },
                new CustomerDetail { Id = 10, Age = 26, Address = "Meram/Konya", CustomerId = 10, Job = "Game Developer" },
                new CustomerDetail { Id = 11, Age = 29, Address = "Seyhan/Adana", CustomerId = 11, Job = "Cyber Security Expert" },
                new CustomerDetail { Id = 12, Age = 31, Address = "Şişli/İstanbul", CustomerId = 12, Job = "AI Engineer" },
                new CustomerDetail { Id = 13, Age = 23, Address = "Tepebaşı/Eskişehir", CustomerId = 13, Job = "Embedded Systems Engineer" },
                new CustomerDetail { Id = 14, Age = 27, Address = "Ortahisar/Trabzon", CustomerId = 14, Job = "Database Administrator" },
                new CustomerDetail { Id = 15, Age = 34, Address = "Odunpazarı/Eskişehir", CustomerId = 15, Job = "Business Analyst" }
            );
        }
    }
}
