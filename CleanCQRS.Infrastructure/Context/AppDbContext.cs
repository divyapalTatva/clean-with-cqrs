using CleanCQRS.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanCQRS.Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Customer> Customers { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<OrderItem> OrderItems { get; set; } = null!;
        public DbSet<Payment> Payments { get; set; } = null!;
        public DbSet<Shipment> Shipments { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Apply all configurations automatically
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            // Data Seeding
            modelBuilder.SeedDefaultData();
            base.OnModelCreating(modelBuilder);
        }
    }
}
