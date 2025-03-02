
using Microsoft.EntityFrameworkCore;
using SaleManagement.Context;
using SaleManagement.Repositories.Implementations;
using SaleManagement.Repositories.Interfaces;
using System.Text.Json.Serialization;

namespace SaleManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddControllers()
            .AddJsonOptions(options =>
            {
                 options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve; // Döngüsel referansları önler
                 options.JsonSerializerOptions.WriteIndented = true; // JSON'u okunabilir hale getirir (Gereksizse kaldır)
            });

            
            builder.Services.AddLogging(); // 🔥 Logger'ı ekledik







            var connStr = builder.Configuration.GetConnectionString("dockerConnection");

            builder.Services.AddDbContext<SaleContext>(options => options.UseSqlServer(connStr));
            builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<IBrandRepository, BrandRepository>();



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
