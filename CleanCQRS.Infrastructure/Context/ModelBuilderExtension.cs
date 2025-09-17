using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;
using CleanCQRS.Domain.Entities;

namespace CleanCQRS.Infrastructure.Context
{
    public static class ModelBuilderExtension
    {
        public static void SeedDefaultData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(
                    new Customer
                    {
                        Id = Guid.Parse("7f8b2a4d-3c91-4e67-b8f5-2d1a9e6c4b73"),
                        FirstName = "Tatva",
                        LastName = "User",
                        Email = "tatva@tatvasoft.com",
                        PhoneNumber = "+91 1234567890",
                    }
            );

            modelBuilder.Entity<Product>().HasData(
                    new Product
                    {
                        Id = Guid.Parse("a3f7d821-94c6-4b2e-8f15-6d9a3e7c2b84"),
                        Name = "Dell OptiPlex 7090 Desktop",
                        Description = "High-performance business desktop computer featuring Intel Core i7 processor, 16GB RAM, 512GB SSD storage. Designed for demanding business applications with enhanced security features and reliable performance for professional workloads",
                        Price = 10000,
                        StockQuantity = 100
                    }
            );

            modelBuilder.Entity<Product>().HasData(
                    new Product
                    {
                        Id = Guid.Parse("2e8b4f93-7a1d-4c56-9b38-f4e2a8d6c179"),
                        Name = "HP EliteBook 850 G8 Laptop",
                        Description = "Premium business laptop with 15.6\" display, Intel Core i5 processor, 8GB RAM, 256GB SSD. Features enterprise-grade security, long battery life, and durable construction perfect for mobile professionals and remote work scenarios",
                        Price = 30000,
                        StockQuantity = 10
                    }
            );
        }
    }

}
