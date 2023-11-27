using Categories.API.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Categories.API.Data.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DbSet<Category> Categories { get; set; }
    }
}
