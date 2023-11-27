using Products.API.Data.Repositories;
using Products.API.Domain.Repository;

namespace Products.API.IoC
{
    public static class RepositoryExtension
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IProductRepository, ProductRepository>();

            return services;
        }
    }
}
