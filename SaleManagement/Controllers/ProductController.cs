using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SaleManagement.Dtos;
using SaleManagement.Models;
using SaleManagement.Repositories.Implementations;
using SaleManagement.Repositories.Interfaces;

namespace SaleManagement.Controllers
{
    [Route("product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repo;
        private readonly ILogger<ProductController> _logger;

        public ProductController(IProductRepository repo, ILogger<ProductController> logger)
        {
            _repo = repo;
            _logger = logger;

        }

        [HttpGet("all-products")]
        public IActionResult GetAllProduct()
        {
            return Ok(_repo.Products);
        }

        [HttpDelete("{Id:int}")]
        public IActionResult DeleteProductById(int Id)
        {
            try
            {
                var DeletedCustomer = GetProductById(Id);

                if (DeletedCustomer == null)
                {
                    _logger.LogError("Aradığınız Id'ye sahip kullanıcı mevcut değil: " + Id);
                    return NotFound(new { message = $"Müşteri bulunamadı. Id: {Id}" });
                }

                _repo.DeleteProduct(Id);
                _logger.LogInformation($"Müşteri silindi. Id: {Id}");

                return Ok(new { message = "Müşteri başarıyla silindi." });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Bir hata oluştu. Id: " + Id);
                return StatusCode(500, new { message = "Bilinmeyen bir hata oluştu." });
            }
        }

        [HttpPut("{Id:int}")]
        public IActionResult UpdateProduct(int Id, [FromBody] ProductDto newProduct)
        {
            try
            {
                var CurrentProduct = GetProductById(Id);

                if (CurrentProduct!=null)
                {
                    if (newProduct == null)
                    {
                        _logger.LogError("Boş Değer Gönderemezsin !");
                        return BadRequest();
                    }


                    _repo.UpdateProduct(Id, newProduct);
                    return Ok(newProduct);
                }

                _logger.LogError("Verilen Id'ye Ait Ürün Bulunamadı ID: " + Id);
                return BadRequest();


                
            }
            catch (Exception ex)
            {
                _logger.LogError("Bilinmeyen Bir Hata Oluştu");
                throw;
            }

        }


        [HttpGet]
        public IActionResult GetNameStock()   
        {
            try
            {
                var productInfos = _repo.GetNameStock();

                if (productInfos == null || productInfos.Count == 0)
                {
                    return NotFound(new { message = "Ürün bilgisi bulunamadı." });
                }

                return Ok(productInfos);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Bir hata oluştu.");
                return StatusCode(500, new { message = "Bilinmeyen bir hata oluştu." });
            }
        }


        [HttpGet("by-price/{Price:int}")]
        public IActionResult GetProductByPrice(int Price)
        {
            try
            {
                var Product = _repo.Products.FirstOrDefault(p => p.Price == Price);

                if (Product == null)
                {
                    _logger.LogError("Verilen Açıklamaya ait bir ürün bulunamadı." + Price);
                    return NotFound(new { message = $" Ürün bulunamadı. Açıklama : {Price}" });
                }
                else
                {
                    var ProductName = _repo.GetProductByPrice(Price);
                    return Ok(ProductName);
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Bir hata oluştu ");
                return StatusCode(500, new { message = "Bilinmeyen bir hata oluştu." });
            }
        }

        [HttpPost("add")]   // Customer Id boş bırakınca FK Hatası Alıyorum // MANTIĞINI TEKRAR ET
        public IActionResult AddProduct([FromBody] ProductDto productDto)
        {
            try
            {
                if (productDto == null)
                {
                    _logger.LogError("Boş bir ürün eklemeye çalışıyorsunuz!");
                    return BadRequest(new { message = "Ürün bilgisi boş olamaz." });
                }

                _repo.AddProduct(productDto);
                return Ok(new { message = "Ürün başarıyla eklendi.", product = productDto });
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Ürün eklenirken hata oluştu.");
                return StatusCode(500, new { message = "Ürün eklenirken bir hata oluştu." });
            }
        }


        [HttpGet("{Id:int}")]
        public IActionResult GetProductById(int Id)
        {
            try
            {
                var Product = _repo.Products.FirstOrDefault(p => p.Id == Id);
                if (Product == null)
                {
                    _logger.LogError("ürün bulunamadı.");
                    return NotFound(new { message = $" Ürün bulunamadı." });
                }
                else
                {
                    var product = _repo.GetProductById(Id);
                    return Ok(product);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Bir hata oluştu ");
                return StatusCode(500, new { message = "Bilinmeyen bir hata oluştu." });
            }
        }



    }
}
