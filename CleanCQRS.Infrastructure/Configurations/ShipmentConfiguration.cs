using CleanCQRS.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CleanCQRS.Infrastructure.Configurations
{
    public class ShipmentConfiguration : IEntityTypeConfiguration<Shipment>
    {
        public void Configure(EntityTypeBuilder<Shipment> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.TrackingNumber)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasOne(s => s.Order)
                .WithMany()
                .HasForeignKey(s => s.OrderId);
        }
    }
}
