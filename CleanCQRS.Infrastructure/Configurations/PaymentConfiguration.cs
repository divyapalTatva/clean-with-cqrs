using CleanCQRS.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CleanCQRS.Infrastructure.Configurations
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Amount)
                .HasPrecision(18, 2);

            builder.HasOne(p => p.Order)
                .WithMany()
                .HasForeignKey(p => p.OrderId);
        }
    }
}
