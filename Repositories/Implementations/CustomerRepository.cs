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

        public CustomerRepository(SaleContext db)
        {
            _db = db;
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
                    throw new KeyNotFoundException($"Müşteri bulunamadı. ID: {Id}");
                }

                _db.Remove(deletedCustomer);
                _db.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("Müşteri silinirken beklenmeyen bir hata oluştu.", e);
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

        public CustomerDto GetCustomerDetailsByName(string Name)
        {
            try
            {
                var customer = _db.Customers
                    .Where(c => c.Firstname == Name)
                    .Select(c => new CustomerDto
                    {
                        Firstname=c.Firstname,
                        Lastname=c.Lastname,
                        Products= c.Products.Select(p=> new ProductDto
                        {
                            Name=p.Name,
                            Description=p.Description,
                            Price=p.Price,
                            Stock= p.Stock
                        }).ToList()


                    }).SingleOrDefault();

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
