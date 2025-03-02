using SaleManagement.Context;
using SaleManagement.Dtos;
using SaleManagement.Models;
using SaleManagement.Repositories.Interfaces;

namespace SaleManagement.Repositories.Implementations
{
    public class BrandRepository : IBrandRepository
    {
        private readonly SaleContext _db;
        private readonly ILogger<BrandRepository> _logger;

        public BrandRepository(SaleContext db,ILogger<BrandRepository> logger)
        {
            _db = db;
            _logger = logger;
        }

        public List<BrandDto> Brands {

            get
            {
                return _db.Brands
                    .Select(b=> new BrandDto
                    {
                        Id = b.Id,
                        Name = b.Name,
                        
                    }).ToList();
            }
        }

        public void DeleteBrand(int Id)
        {
            try
            {
                var DeletedBrand = GetBrandById(Id);

                if (DeletedBrand == null)
                {
                    _logger.LogError("");
                }

            }catch (Exception ex)
            {
                throw new Exception("Bilinmeyen bir hata oluştu");
            }
        }

        public List<BrandDto> GetAllBrandsProducts()
        {

            try
            {
                var BrandsProduct = _db.Brands.Select(b => new BrandDto
                {
                    Id = b.Id,
                    Name = b.Name,
                    Products = b.Products.Select(p => new ProductDto
                    {
                        Id = p.Id,
                        Description = p.Description,
                        Name = p.Name,
                        Price = p.Price,
                        Stock = p.Stock
                    }).ToList()
                }).ToList();

                if (!BrandsProduct.Any())
                {
                    _logger.LogError("Markaya Ait Ürün Bulunamadı");
                    return new List<BrandDto>();
                }

                    return BrandsProduct;
                

                
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Markalar ve ürünler alınırken bir hata oluştu.");
                throw; 
            }



        }

        public Brand GetBrandById(int Id)
        {
            try
            {
                var Brand = _db.Brands.FirstOrDefault(b => b.Id == Id);

                if (Brand == null)
                {
                    _logger.LogError("Marka Bulunamadı. ");
                    return null;
                }
                else
                {
                    return Brand;
                }

            }catch (Exception ex)
            {
                throw new Exception("Bilinmeyen Bir Hata Oluştu");
            }
        }

        public BrandDto GetProductsByBrand(string Name)
        {
            try
            {
                var Product = _db.Brands.
                    Where(b => b.Name == Name)
                    .Select(b => new BrandDto
                    {
                        Id = b.Id,
                        Name = b.Name,
                        Products = b.Products.Select(p => new ProductDto
                        {
                            Id = p.Id,
                            Description = p.Description,
                            Name = p.Name,
                            Price = p.Price,
                            Stock= p.Stock,
                        }).ToList()
                    }).FirstOrDefault();

                if (Product==null)
                {
                    _logger.LogError("Markaya Ait Ürün Bulunamadı");
                    return null;
                }

                return Product;


            }
            catch (Exception ex)
            {
                _logger.LogError(ex,"Bilinmeyen bir problem oluştu");
                throw;
            }
        }
    }
}
