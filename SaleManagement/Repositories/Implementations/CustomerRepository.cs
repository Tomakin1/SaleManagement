using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using SaleManagement.Context;
using SaleManagement.Dtos;
using SaleManagement.Models;
using SaleManagement.Repositories.Interfaces;

namespace SaleManagement.Repositories.Implementations
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly SaleContext _db;
        private readonly ILogger<CustomerRepository> _logger;

        public CustomerRepository(SaleContext db, ILogger<CustomerRepository> logger)
        {
            _db = db;
            _logger = logger;
        }

        
        public List<CustomerDto> Customers
        {
            get
            {
                return _db.Customers
                    .Select(c => new CustomerDto
                    {
                        Id = c.Id,
                        Firstname = c.Firstname,
                        Lastname = c.Lastname,

                        
                    }).ToList();
            }
        }

        public void DeleteCustomer(int Id)
        {
            try
            {
                var deletedCustomer = _db.Customers.Find(Id);

                if (deletedCustomer == null)
                {
                    _logger.LogError("Verilen Id'ye Sahip Bir Kullanıcı bulunamadı" +Id);
                    return;
                }

                _db.Remove(deletedCustomer);
                _db.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("Müşteri silinirken beklenmeyen bir hata oluştu.", e);
            }
        }

        public void AddCustomer(CustomerDto customerDto) // MANTIĞINI TEKRAR ET
        {
            try
            {
                var newCustomer = new Customer
                {
                    Firstname = customerDto.Firstname,
                    Lastname = customerDto.Lastname,
                    Products = customerDto.Products?.Select(p => new Product
                    {
                        Name = p.Name,
                        Price = p.Price,
                        Stock = p.Stock,
                        Description = p.Description,
                        BrandId = p.BrandId

                    }).ToList(),

                    CustomerDetail=customerDto.CustomerDetailDto != null ? new CustomerDetail
                    {
                        Age=customerDto.CustomerDetailDto.Age,
                        Address=customerDto.CustomerDetailDto.Address,
                        Job=customerDto.CustomerDetailDto.Job,
                        
                    } : null
                };
                _db.Customers.Add(newCustomer);
                _db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Hata oluştu: {e.Message}");
                Console.WriteLine($"Inner Exception: {e.InnerException?.Message}");
                Console.WriteLine($"StackTrace: {e.StackTrace}");
                throw;
            }

        }



        public void UpdateCustomer(int Id, CustomerDto newCustomerDetail)
        {
            try
            {
                var CurrentCustomerDetail = GetCustomerById(Id);

                if (CurrentCustomerDetail==null)
                {
                    _logger.LogError("Verilen Id'ye Sahip Bir Kullanıcı Bulunamadı");
                    return;
                }

                CurrentCustomerDetail.Firstname = newCustomerDetail.Firstname;
                CurrentCustomerDetail.Lastname = newCustomerDetail.Lastname;
                





                _db.Update(CurrentCustomerDetail);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Bilinmeyen Bir Hata Oluştu: {ex.Message}");
                throw;
            }
        }






        public Customer GetCustomerById(int Id)
        {
            try
            {
                var customer = _db.Customers.FirstOrDefault(c => c.Id == Id);
                    

                
                if (customer == null)
                {
                    throw new KeyNotFoundException($"Müşteri bulunamadı. ID: {Id}");
                }

                return customer;
            }
            catch (Exception e)
            {
                throw new Exception("Müşteri alınırken beklenmeyen bir hata oluştu.", e);
            }
        }

        public CustomerDto GetCustomerDetailsByName(string Name) // MANTIĞINI TEKRAR ET
        {
            try
            {
                var customer = _db.Customers
                    .Where(c => c.Firstname == Name)
                    .Select(x => new CustomerDto
                    {
                        Id = x.Id,
                        Firstname = x.Firstname,
                        Lastname = x.Lastname,
                        CustomerDetailDto = x.CustomerDetail != null ? new CustomerDetailDto
                        {
                            Id = x.CustomerDetail.Id,
                            Age = x.CustomerDetail.Age,
                            Address = x.CustomerDetail.Address,
                            Job = x.CustomerDetail.Job
                        } : null
                    }).FirstOrDefault();

                if (customer == null)
                {
                    throw new KeyNotFoundException($"Müşteri bulunamadı. İSİM: {Name}");
                }

                return customer;
            }
            catch (Exception e)
            {
                throw new Exception("Müşteri alınırken beklenmeyen bir hata oluştu.", e);
            }
        }


        public CustomerDto GetCustomerProductsByName(string Firstname, string Lastname)
        {
            try
            {
                var customer = _db.Customers
                    .Where(c => c.Firstname == Firstname && c.Lastname == Lastname)
                    .Select(c => new CustomerDto
                    {
                        Firstname = c.Firstname,
                        Lastname = c.Lastname,
                        Products = c.Products.Select(p => new ProductDto
                        {
                            Name=p.Name,
                            Description= p.Description,
                            Price=p.Price,
                            Stock=p.Stock
                        }).ToList()
                    }).FirstOrDefault();

                if (customer == null)
                {
                    throw new KeyNotFoundException($"Müşteri bulunamadı. İSİM: {Firstname}");
                }

                return customer;
            }
            catch (Exception e)
            {
                throw new Exception("Müşteri alınırken beklenmeyen bir hata oluştu.", e);
            }
        }
    }
}
