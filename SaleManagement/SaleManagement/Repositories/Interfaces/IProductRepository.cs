using SaleManagement.Dtos;
using SaleManagement.Models;

namespace SaleManagement.Repositories.Interfaces
{
    public interface IProductRepository
    {
        void DeleteProduct(int Id);
        List<ProductDto> Products { get; }
        Product GetProductById(int Id);
        ProductDto GetProductBrandByName(string name);
        List<ProductDto> GetNameStock();   //  ürünlerin ürün ve stok bilgilerini getirmek için ismi bu şekilde yazdım
        ProductDto GetProductByPrice(int Price);

    }
}
