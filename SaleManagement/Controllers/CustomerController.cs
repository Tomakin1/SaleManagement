using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SaleManagement.Context;
using SaleManagement.Dtos;
using SaleManagement.Models;
using SaleManagement.Repositories.Implementations;
using SaleManagement.Repositories.Interfaces;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SaleManagement.Controllers
{
    [Route("customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _repo;
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(ICustomerRepository repo, ILogger<CustomerController> logger)
        {
            _repo = repo;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAllCustomers()
        {
            try
            {
                var customers = _repo.Customers.ToList();

                if (customers==null)
                {
                    _logger.LogError("Customer Listesi Boş");
                    return NotFound(new { message = "Bilinmeyen Bir HATA oluştu" });
                }

                return Ok(customers);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex + "Bir hata oluştu. " );
                return StatusCode(500, new { message = "Bilinmeyen bir hata oluştu." });

            }
        }

        [HttpDelete("{Id:int}")]
        public IActionResult DeleteCustomer(int Id)
        {
            try
            {
                var deletedCustomer = _repo.GetCustomerById(Id);

                if (deletedCustomer == null) 
                {
                    _logger.LogError("Aradığınız Id'ye sahip kullanıcı mevcut değil: " + Id);
                    return NotFound(new { message = $"Müşteri bulunamadı. Id: {Id}" }); 
                }

                _repo.DeleteCustomer(Id);
                _logger.LogInformation($"Müşteri silindi. Id: {Id}");

                return Ok(new { message = "Müşteri başarıyla silindi." }); 
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Bir hata oluştu. Id: " + Id); 
                return StatusCode(500, new { message = "Bilinmeyen bir hata oluştu." }); 
            }
        }


        [HttpGet("{Id:int}")]
        public IActionResult GetCustomerById(int Id)
        {
            try
            {
                var Customer = _repo.GetCustomerById(Id);

                if (Customer==null)
                {
                    _logger.LogError("Aradağınız Id'ye Sahip Kullanıcı Mevcut Değil" + Id);
                    return NotFound(new { message = $"Müşteri bulunamadı. Id: {Id}" }); 
                }

                return Ok(Customer);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Bir hata oluştu. Id: " + Id);
                return StatusCode(500, new { message = "Bilinmeyen bir hata oluştu." });
            }
        }

        //[HttpPost]
        //public IActionResult AddCustomer([FromBody] Customer customer)
        //{
        //    if (customer == null)
        //    {
        //        return BadRequest("Geçersiz müşteri verisi.");
        //    }

        //    try
        //    {
        //        _repo.AddCustomer(customer);
        //        return StatusCode(201, "Müşteri Eklendi");
        //    }
        //    catch (Exception e)
        //    {
        //        return StatusCode(500, $"Müşteri eklenirken bir hata oluştu: {e.Message}");
        //    }
        //}


        [HttpGet("{FirstName}")]
        public IActionResult getCustomerDetailsByName(string FirstName)
        {
            try
            {
                var Customer = _repo.Customers.FirstOrDefault(c => c.Firstname == FirstName);

                if (Customer == null)
                {
                    _logger.LogError("Aradağınız İsime Sahip Kullanıcı Mevcut Değil" + FirstName);
                    return NotFound(new { message = $"Müşteri bulunamadı. İSİM: {FirstName}" });

                }

                return Ok(_repo.GetCustomerDetailsByName(FirstName));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Bir hata oluştu. İsim: " + FirstName);
                return StatusCode(500, new { message = "Bilinmeyen bir hata oluştu." });
            }
        }



        [HttpGet("{Firstname}/{Lastname}")]
        public IActionResult GetCustomerProductsByName(string Firstname , string Lastname)
        {
            try
            {
                var customer = _repo.GetCustomerProductsByName(Firstname, Lastname);

                if (customer==null)
                {
                    _logger.LogError("Aradığınız isim ve soyisim'e uygun bir kişi bulunamadı " + Firstname);
                    return NotFound(new { message = "Müşteri Bulunamadı" });
                }

                return Ok(customer);


            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Bir hata oluştu. İsim: " + Firstname);
                return StatusCode(500, new { message = "Bilinmeyen bir hata oluştu." });
            }

        }
    }
}
