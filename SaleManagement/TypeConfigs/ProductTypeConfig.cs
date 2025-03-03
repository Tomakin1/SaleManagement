using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaleManagement.Models;
using System.Reflection.Emit;

namespace SaleManagement.TypeConfig
{
    public class ProductTypeConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Description).IsRequired().HasMaxLength(200);

            builder.HasOne(p => p.Brand).WithMany(c => c.Products)
                .HasForeignKey(p => p.BrandId);


            builder.HasData(

                new Product { Id = 1, Name = "Dizüstü Bilgisayar", Price = 100, Description = "Taşınabilir bilgisayar", BrandId = 1, CustomerId = 1, Stock = 1 },
                new Product { Id = 2, Name = "Akıllı Telefon", Price = 200, Description = "Son model akıllı telefon", BrandId = 2, CustomerId = 2, Stock = 5 },
                new Product { Id = 3, Name = "Kablosuz Kulaklık", Price = 50, Description = "Bluetooth destekli kulaklık", BrandId = 3, CustomerId = 3, Stock = 10 },
                new Product { Id = 4, Name = "Akıllı Saat", Price = 120, Description = "Sağlık takibi yapabilen saat", BrandId = 4, CustomerId = 4, Stock = 3 },  
                new Product { Id = 5, Name = "Mekanik Klavye", Price = 80, Description = "RGB ışıklı mekanik klavye", BrandId = 5, CustomerId = 5, Stock = 7 },  
                new Product { Id = 6, Name = "Oyun Mouse", Price = 40, Description = "Hassasiyet ayarlı oyun mouse", BrandId = 5, CustomerId = 6, Stock = 4 }, 
                new Product { Id = 7, Name = "Monitör", Price = 300, Description = "144Hz oyuncu monitörü", BrandId = 4, CustomerId = 7, Stock = 2 },  
                new Product { Id = 8, Name = "Tablet", Price = 180, Description = "Çok amaçlı tablet", BrandId = 2, CustomerId = 8, Stock = 6 },  
                new Product { Id = 9, Name = "Harici Disk", Price = 90, Description = "1TB taşınabilir disk", BrandId = 3, CustomerId = 9, Stock = 8 }, 
                new Product { Id = 10, Name = "Hoparlör", Price = 70, Description = "Kablosuz taşınabilir hoparlör", BrandId = 3, CustomerId = 10, Stock = 5 }, 
                new Product { Id = 11, Name = "USB Bellek", Price = 20, Description = "64GB USB bellek", BrandId = 6, CustomerId = 11, Stock = 15 },  
                new Product { Id = 12, Name = "Masaüstü Bilgisayar", Price = 500, Description = "Oyun için güçlü bilgisayar", BrandId = 6, CustomerId = 12, Stock = 1 },  
                new Product { Id = 13, Name = "Router", Price = 60, Description = "Yüksek hızlı WiFi yönlendirici", BrandId = 6, CustomerId = 13, Stock = 9 },  
                new Product { Id = 14, Name = "Web Kamera", Price = 45, Description = "Full HD web kamera", BrandId = 5, CustomerId = 14, Stock = 3 },  
                new Product { Id = 15, Name = "VR Gözlük", Price = 250, Description = "Sanal gerçeklik gözlüğü", BrandId = 3, CustomerId = 15, Stock = 2 }   
            );
        }
    }
}
