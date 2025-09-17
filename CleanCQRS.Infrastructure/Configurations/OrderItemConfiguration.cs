using CleanCQRS.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CleanCQRS.Infrastructure.Configurations
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasKey(oi => oi.Id);

            builder.Property(oi => oi.UnitPrice)
                .HasPrecision(18, 2);
        }
    }
}
