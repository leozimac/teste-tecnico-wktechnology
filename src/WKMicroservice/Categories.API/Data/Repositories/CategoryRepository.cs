using Categories.API.Data.Context;
using Categories.API.Domain.DTOs;
using Categories.API.Domain.Entities;
using Categories.API.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Categories.API.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _context;

        public CategoryRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<int> AddAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
            return await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Category category)
        {
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }

        public async Task<List<CategoryDto>> GetAllAsync()
        {
            return await _context.Categories
                .AsNoTracking()
                .Select(c => new CategoryDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description,
                }).ToListAsync();
        }

        public async Task<Category?> GetByIdAsync(int id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task<List<CategoryMenuDto>> GetCategoryForMenusAsync()
        {
            return await _context.Categories
                .AsNoTracking()
                .Select(c => new CategoryMenuDto
                {
                    Id = c.Id,
                    Name = c.Name,
                }).ToListAsync();
        }

        public async Task<CategoryDto?> GetDetailsAsync(int id)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id.Equals(id));

            if (category is null)
                return null;

            return new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
            };
        }

        public async Task UpdateAsync(Category category)
        {
            await _context.SaveChangesAsync();
        }
    }
}
