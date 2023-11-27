using Products.API.Domain.DTOs;
using Products.API.Domain.Entities;

namespace Products.API.Domain.Repository
{
    public interface IProductRepository
    {
        Task<List<ProductDto>> GetAllAsync();
        Task<ProductDetailsDto?> GetDetailsAsync(int id);
        Task<Product?> GetByIdAsync(int id);
        Task<int> AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(Product product);
    }
}
