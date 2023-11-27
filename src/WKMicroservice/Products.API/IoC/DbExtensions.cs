using Microsoft.EntityFrameworkCore;
using Products.API.Data.Context;

namespace Products.API.IoC
{
    public static class DbExtensions
    {
        public static IServiceCollection AddMySql(this IServiceCollection services, IConfiguration configuration)
        {
            var mySqlConnection = configuration.GetConnectionString("MySqlConnection");
            services.AddDbContext<DataContext>(o => o.UseMySql(mySqlConnection, ServerVersion.AutoDetect(mySqlConnection)));

            return services;
        }
    }
}
