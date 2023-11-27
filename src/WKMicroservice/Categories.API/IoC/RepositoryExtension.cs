using Categories.API.Data.Repositories;
using Categories.API.Domain.Repository;

namespace Categories.API.IoC
{
    public static class RepositoryExtension
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<ICategoryRepository, CategoryRepository>();

            return services;
        }
    }
}
