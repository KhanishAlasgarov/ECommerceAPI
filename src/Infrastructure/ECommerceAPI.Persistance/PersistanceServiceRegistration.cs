using ECommerceAPI.Application.Repositories.Customers;
using ECommerceAPI.Application.Repositories.Orders;
using ECommerceAPI.Application.Repositories.Products;
using ECommerceAPI.Persistance.Contexts;
using ECommerceAPI.Persistance.Repositories.Customers;
using ECommerceAPI.Persistance.Repositories.Orders;
using ECommerceAPI.Persistance.Repositories.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerceAPI.Persistance
{
    public static class PersistanceServiceRegistration
    {
        public static IServiceCollection AddPersistanceService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BaseDbContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("Local"));
            }, ServiceLifetime.Scoped);

            services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
            services.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();


            services.AddScoped<IOrderReadRepository, OrderReadRepository>();
            services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();

            services.AddScoped<IProductReadRepository, ProductReadRepository>();
            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();


            return services;
        }
    }
}
