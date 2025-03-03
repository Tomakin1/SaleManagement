using Microsoft.EntityFrameworkCore;
using SaleManagement.Context;
using SaleManagement.Dtos;
using SaleManagement.Models;
using SaleManagement.Repositories.Interfaces;

namespace SaleManagement.Repositories.Implementations
{
    public class ProductRepository : IProductRepository
    {
        private readonly SaleContext _db;
        private readonly ILogger<ProductRepository> _logger;


        public ProductRepository(SaleContext db,ILogger<ProductRepository> logger)
        {
            _db = db;
            _logger = logger;
        }

        public List<ProductDto> Products {

            get
            {


                return _db.Products
                    .Select(p => new ProductDto
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Description = p.Description,
                        Price = p.Price,
                        Stock = p.Stock
                    }).ToList();

            }

        }

        public void DeleteProduct(int Id)
        {
            try
            {
                var DeletedProduct = _db.Products.FirstOrDefault(p => p.Id == Id);

                if (DeletedProduct == null)
                {
                    _logger.LogError($"Bu Id'ye sahip bir ürün bulunamadı. Id: {Id}");
                    return; 
                }

                _db.Products.Remove(DeletedProduct);
                _db.SaveChanges();

                _logger.LogInformation($"Ürün başarıyla silindi. Id: {Id}");
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Veritabanı hatası oluştu. Id: {Id}");
                throw new Exception("Bilinmeyen bir hata oluştu", e); 
            }
        }

        public void UpdateProduct(int Id, ProductDto productDto)
        {
            try
            {
                var CurrentProduct = GetProductById(Id);

                if (CurrentProduct == null)
                {
                    _logger.LogError("Verilen Id'ye Ait Ürün Bulunamadı");
                    return;
                }

                
                CurrentProduct.Name = productDto.Name;
                CurrentProduct.Description = productDto.Description;
                CurrentProduct.Price = productDto.Price;
                CurrentProduct.Stock = productDto.Stock;

                _db.Products.Update(CurrentProduct);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Bilinmeyen Bir Hata Oluştu: {ex.Message}");
                throw;
            }
        }



        public List<ProductDto> GetNameStock()
        {
            try
            {
                if (_db.Products == null)
                {
                    _logger.LogError("Veritabanı bağlantısı yok veya Products tablosu bulunamadı.");
                    return new List<ProductDto>(); 
                }

                var productInfos = _db.Products
                    .Select(p => new ProductDto
                    {
                        Name = p.Name,
                        Stock = p.Stock
                    })
                    .ToList();

                if (productInfos.Count == 0)
                {
                    _logger.LogWarning("Veritabanında hiç ürün bulunamadı.");
                }

                return productInfos;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Veritabanı hatası oluştu.");
                throw; 
            }
        }



        public ProductDto GetProductByPrice(int Price)
        {
            try
            {
                var Product = _db.Products
                    .Where(p => p.Price == Price)
                    .Select(p => new ProductDto
                    {
                        Id=1,
                        Name=p.Name,
                        Description=p.Description,
                        Stock=p.Stock,
                    }).FirstOrDefault();
                    

                if (Product==null)
                {
                    _logger.LogError("BİLİNMEYEN BİR HATA OLUŞTU Price :  " + Price);
                    return null;
                }
                else
                {
                    return Product;
                }


            }
            catch (Exception e)
            {
                throw new Exception("BİLİNMEYEN BİR HATA OLUŞTU");
            }
        }

        public Product GetProductById(int Id)
        {
            var product = _db.Products.FirstOrDefault(p => p.Id == Id);

            if (product==null)
            {
                return null;
            }
            
            return product;
        }

        public void AddProduct(ProductDto productDto) // Tekrar Et
        {
            try
            {
                var newProduct = new Product
                {
                    Name = productDto.Name,
                    Price = productDto.Price,
                    Stock = productDto.Stock,
                    Description = productDto.Description,
                    CustomerId = productDto.CustomerId,
                    BrandId = productDto.BrandId

                };

                _db.Products.Add(newProduct);
                _db.SaveChanges();
                
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ürün eklenirken bir hata oluştu.");
                throw new Exception("Bilinmeyen bir hata oluştu", ex);
            }
        }

    }
}
