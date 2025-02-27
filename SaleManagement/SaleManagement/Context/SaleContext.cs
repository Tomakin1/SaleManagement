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
            // Customer Entity Data Relation

            modelBuilder.Entity<Customer>().HasKey(c => c.Id);

            modelBuilder.Entity<Customer>().Property(c => c.Firstname).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Customer>().Property(c => c.Lastname).IsRequired().HasMaxLength(50);

            modelBuilder.Entity<Customer>().HasOne(c => c.CustomerDetail).WithOne(c => c.Customer)
                .HasForeignKey<CustomerDetail>(c => c.CustomerId);

            modelBuilder.Entity<Customer>().HasMany(c=>c.Products).WithOne(p=>p.Customer)
                .HasForeignKey(p=>p.CustomerId);

            // Product Entity Data Relation

            modelBuilder.Entity<Product>().HasKey(p => p.Id);  

            modelBuilder.Entity<Product>().Property(p=>p.Name).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Product>().Property(p=>p.Description).IsRequired().HasMaxLength(200);

            modelBuilder.Entity<Product>().HasOne(p=>p.Brand).WithMany(c => c.Products)
                .HasForeignKey(p=>p.BrandId);


            modelBuilder.Entity<Customer>().HasData(

                new Customer { Id = 1,Firstname="Ömer",Lastname="Tomakin" },
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

            modelBuilder.Entity<CustomerDetail>().HasData(

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


            modelBuilder.Entity<Product>().HasData(

    new Product { Id = 1, Name = "Dizüstü Bilgisayar", Price = 100, Description = "Taşınabilir bilgisayar", BrandId = 1, CustomerId = 1, Stock = 1 }, // Monster
    new Product { Id = 2, Name = "Akıllı Telefon", Price = 200, Description = "Son model akıllı telefon", BrandId = 2, CustomerId = 2, Stock = 5 }, // Apple
    new Product { Id = 3, Name = "Kablosuz Kulaklık", Price = 50, Description = "Bluetooth destekli kulaklık", BrandId = 3, CustomerId = 3, Stock = 10 }, // Sony
    new Product { Id = 4, Name = "Akıllı Saat", Price = 120, Description = "Sağlık takibi yapabilen saat", BrandId = 4, CustomerId = 4, Stock = 3 }, // Samsung
    new Product { Id = 5, Name = "Mekanik Klavye", Price = 80, Description = "RGB ışıklı mekanik klavye", BrandId = 5, CustomerId = 5, Stock = 7 }, // Logitech
    new Product { Id = 6, Name = "Oyun Mouse", Price = 40, Description = "Hassasiyet ayarlı oyun mouse", BrandId = 5, CustomerId = 6, Stock = 4 }, // Logitech
    new Product { Id = 7, Name = "Monitör", Price = 300, Description = "144Hz oyuncu monitörü", BrandId = 4, CustomerId = 7, Stock = 2 }, // Samsung
    new Product { Id = 8, Name = "Tablet", Price = 180, Description = "Çok amaçlı tablet", BrandId = 2, CustomerId = 8, Stock = 6 }, // Apple
    new Product { Id = 9, Name = "Harici Disk", Price = 90, Description = "1TB taşınabilir disk", BrandId = 3, CustomerId = 9, Stock = 8 }, // Sony
    new Product { Id = 10, Name = "Hoparlör", Price = 70, Description = "Kablosuz taşınabilir hoparlör", BrandId = 3, CustomerId = 10, Stock = 5 }, // Sony
    new Product { Id = 11, Name = "USB Bellek", Price = 20, Description = "64GB USB bellek", BrandId = 6, CustomerId = 11, Stock = 15 }, // Asus
    new Product { Id = 12, Name = "Masaüstü Bilgisayar", Price = 500, Description = "Oyun için güçlü bilgisayar", BrandId = 6, CustomerId = 12, Stock = 1 }, // Asus
    new Product { Id = 13, Name = "Router", Price = 60, Description = "Yüksek hızlı WiFi yönlendirici", BrandId = 6, CustomerId = 13, Stock = 9 }, // Asus
    new Product { Id = 14, Name = "Web Kamera", Price = 45, Description = "Full HD web kamera", BrandId = 5, CustomerId = 14, Stock = 3 }, // Logitech
    new Product { Id = 15, Name = "VR Gözlük", Price = 250, Description = "Sanal gerçeklik gözlüğü", BrandId = 3, CustomerId = 15, Stock = 2 }  // Sony
            );

            modelBuilder.Entity<Brand>().HasData(

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
