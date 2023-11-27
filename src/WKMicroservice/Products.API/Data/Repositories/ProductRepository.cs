using Microsoft.EntityFrameworkCore;
using Products.API.Data.Context;
using Products.API.Domain.DTOs;
using Products.API.Domain.Entities;
using Products.API.Domain.Repository;

namespace Products.API.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;

        public ProductRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<int> AddAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            return await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Product product)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ProductDto>> GetAllAsync()
        {
            return await _context.Products
                .Include(p => p.Category)
                .AsNoTracking()
                .Select(p => new ProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    Category = p.Category.Name
                })
                .ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<ProductDetailsDto?> GetDetailsAsync(int id)
        {
            var product = await _context.Products.
                Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id.Equals(id));

            if (product is null)
                return null;

            return new ProductDetailsDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                IdCategory = product.IdCategory,
                Category = product.Category.Name
            };
        }

        public async Task UpdateAsync(Product product)
        {
            await _context.SaveChangesAsync();
        }
    }
}
