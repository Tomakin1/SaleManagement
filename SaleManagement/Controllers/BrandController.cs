﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SaleManagement.Dtos;
using SaleManagement.Models;
using SaleManagement.Repositories.Interfaces;

namespace SaleManagement.Controllers
{
    [Route("Brand")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandRepository _repo;
        private  readonly ILogger<BrandController> _logger;

        public BrandController(IBrandRepository repo, ILogger<BrandController> logger)
        {
            _repo = repo;
            _logger = logger;
        }

        [HttpGet("Brands")]
        public IActionResult GetAllBrands()
        {

            try
            {
                var Brands = _repo.Brands;

                if (!Brands.Any())
                {
                    _logger.LogError("Markalar getirilirken bir hata oluştu");
                    return StatusCode(500);
                }

                return Ok(Brands);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex,"Bilinmeyen Bir Hata Oluştu");
                throw;
            }
           
        }

        [HttpDelete("{Id:int}")]
        public IActionResult DeleteBrand(int Id)
        {
            try
            {
                var DeletedBrand = _repo.GetBrandById(Id);

                if (DeletedBrand == null)
                {
                    _logger.LogError("Verilen Idye Sahip Bir Marka Bulunamadı ID: "+Id);
                    return BadRequest();
                }

                _repo.DeleteBrand(Id);
                return Ok(DeletedBrand);

            }catch (Exception ex)
            {
                _logger.LogError("Bilinmeyen Bir Hata Oluştu");
                throw;
            }
        }

        [HttpPut("{Id:int}")]
        public IActionResult UpdateBrand(int Id, [FromBody] BrandDto newBrand)
        {
            try
            {
                var CurrentBrand = GetBrandById(Id);

                if (CurrentBrand != null)
                {
                    if (newBrand == null)
                    {
                        _logger.LogError("Boş Değer Gönderemezsin !");
                        return BadRequest();
                    }


                    _repo.UpdateBrand(Id, newBrand);
                    return Ok(newBrand);
                }

                _logger.LogError("Verilen Id'ye Ait Marka Bulunamadı ID: " + Id);
                return BadRequest();



            }
            catch (Exception ex)
            {
                _logger.LogError("Bilinmeyen Bir Hata Oluştu");
                throw;
            }

        }

        [HttpGet]
        public IActionResult GetAllBrandsProducts()
        {
            try
            {
                var BrandsProduct = _repo.GetAllBrandsProducts();

                if (!BrandsProduct.Any())
                {
                    _logger.LogError("Markaya Ait Ürünler Getirilirken Bir Hata Oluştu");
                    return StatusCode(500);
                }

                return Ok(BrandsProduct);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Bilinmeyen Bir Hata Oluştu");
                throw;
            }
        }

        [HttpGet("{Id:int}")]
        public IActionResult GetBrandById(int Id)
        {
            try
            {
                var Brand = _repo.GetBrandById(Id);

                if (Brand==null)
                {
                    _logger.LogError("Marka Bulunamadı Id: "+Id);
                    return BadRequest();
                }

                return Ok(Brand);


            }
            catch(Exception ex)
            {
                _logger.LogError("Bilinmeyen Bir hata oluştu");
                throw;
            }
        }

        [HttpPost]   // MANTIĞINI TEKRAR ET
        public IActionResult AddBrand([FromBody] BrandDto brandDto)
        {
            try
            {
                if (brandDto == null || string.IsNullOrWhiteSpace(brandDto.Name))
                {
                    _logger.LogError("Marka adı boş olamaz!");
                    return BadRequest("Marka adı boş olamaz!");
                }

                _repo.AddBrand(brandDto);
                return Ok(brandDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Marka eklenirken hata oluştu.");
                return StatusCode(500, "Marka eklenirken bir hata oluştu.");
            }
        }




        [HttpGet("product-brand/{Name}")]
        public IActionResult GetProductsByBrand(string Name)
        {
            try
            {
                var Product =_repo.GetProductsByBrand(Name);

                if (Product == null)
                {
                    _logger.LogError("Markaya Ait Ürün Bulunamadı");
                    return BadRequest();
                }

                return Ok(Product);


            }
            catch(Exception ex)
            {
                _logger.LogError(ex,"Bilinmeyen Bir Hata Oluştu");
                throw;
            }

        }


    }
}
