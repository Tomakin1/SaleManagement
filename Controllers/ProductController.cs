﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        public IActionResult GetAllProduct()
        {
            return Ok(_repo.Products);
        }

        [HttpDelete("by-id/{Id:int}")]
        public IActionResult DeleteProduct(int Id)
        {
            try
            {
                var deletedCustomer = _repo.GetProductById(Id);

                if (deletedCustomer == null)
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

        //[HttpGet]
        //public IActionResult GetNameStock()   // APİ çöküyor
        //{
        //    try
        //    {
        //        var productInfos = _repo.GetNameStock();

        //        if (productInfos == null || productInfos.Count == 0)
        //        {
        //            return NotFound(new { message = "Ürün bilgisi bulunamadı." });
        //        }

        //        return Ok(productInfos);
        //    }
        //    catch (Exception e)
        //    {
        //        _logger.LogError(e, "Bir hata oluştu.");
        //        return StatusCode(500, new { message = "Bilinmeyen bir hata oluştu." });
        //    }
        //}




        [HttpGet("by-name/{Name}")]   // Çalışmıyor Ürün Bulunamadı dönüyor
        public IActionResult GetProductBrandByName(string Name)
        {
            try
            {
                var Brand = _repo.Products.FirstOrDefault(p => p.Name == Name);

                if (Brand == null)
                {
                    _logger.LogError("Aradığınız İsime sahip Marka mevcut değil ya da Ürün ismi yanlış girildi isim: " + Name);
                    return NotFound(new { message = $"Ürün ya da marka bulunamadı. İsim: {Name}" });
                }
                else
                {
                    _repo.GetProductBrandByName(Name);
                    return Ok(new { message = "Ürünün Markası Bulundu." });
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Bir hata oluştu ");
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
