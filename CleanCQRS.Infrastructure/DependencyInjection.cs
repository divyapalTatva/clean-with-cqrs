using CleanCQRS.Application.Abstractions;
using CleanCQRS.Infrastructure.Repositories;
using CleanCQRS.Infrastructure.Context;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace CleanCQRS.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // EF Core DbContext with PostgreSQL
            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            // Repositories
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();

            return services;
        }
    }
}