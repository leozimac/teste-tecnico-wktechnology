using Categories.API.Domain.DTOs;
using Categories.API.Domain.Entities;

namespace Categories.API.Domain.Repository
{
    public interface ICategoryRepository
    {
        Task<List<CategoryDto>> GetAllAsync();
        Task<List<CategoryMenuDto>> GetCategoryForMenusAsync();
        Task<CategoryDto?> GetDetailsAsync(int id);
        Task<Category?> GetByIdAsync(int id);
        Task<int> AddAsync(Category category);
        Task UpdateAsync(Category category);
        Task DeleteAsync(Category category);
    }
}
