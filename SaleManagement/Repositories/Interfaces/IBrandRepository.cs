using SaleManagement.Dtos;
using SaleManagement.Models;

namespace SaleManagement.Repositories.Interfaces
{
    public interface IBrandRepository
    {
        void DeleteBrand(int Id);
        List<BrandDto> Brands { get; }
        Brand GetBrandById(int Id);
        List<BrandDto> GetAllBrandsProducts();  // bütün markaları ürünleriyle getirmek için
        BrandDto GetProductsByBrand(string Name); // ismi verilen markanın ürünleri


    }
}
