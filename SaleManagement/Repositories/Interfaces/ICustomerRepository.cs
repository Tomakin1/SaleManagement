using SaleManagement.Dtos;
using SaleManagement.Models;

namespace SaleManagement.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        void DeleteCustomer(int Id);
        List<CustomerDto> Customers { get; }
        Customer GetCustomerById(int Id);
        CustomerDto GetCustomerDetailsByName(string Name);
        CustomerDto GetCustomerProductsByName(string Firstname, string Lastname);
        void AddCustomer(CustomerDto customerDto);

        void UpdateCustomer(int Id, CustomerDto customerDetail);

    }
}
