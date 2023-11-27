using Microsoft.EntityFrameworkCore;
using Products.API.Data.Context;

namespace Products.API.IoC
{
    public static class DbExtensions
    {
        public static IServiceCollection AddMySql(this IServiceCollection services, IConfiguration configuration, string dbHost, string dbName, string dbPassword)
        {
            string mySqlConnection = "";

            if (string.IsNullOrEmpty(dbHost) || string.IsNullOrEmpty(dbName) || string.IsNullOrEmpty(dbPassword))
                mySqlConnection = configuration.GetConnectionString("MySqlConnection")!;
            else
                mySqlConnection = $"Server={dbHost}; Port=3306; Database={dbName}; User=root; Password={dbPassword}; Persist Security Info=False; Connect Timeout=300";
            
            services.AddDbContext<DataContext>(o => o.UseMySql(mySqlConnection, ServerVersion.AutoDetect(mySqlConnection)));

            return services;
        }
    }
}
