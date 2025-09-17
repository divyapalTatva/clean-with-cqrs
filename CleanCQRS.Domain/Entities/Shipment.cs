using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCQRS.Domain.Entities
{
    public class Shipment
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid OrderId { get; set; }
        public Order Order { get; set; } = null!;

        public string TrackingNumber { get; set; } = null!;
        public DateTime ShippedDate { get; set; }
        public DateTime? DeliveredDate { get; set; }
        public ShipmentStatus Status { get; set; } = ShipmentStatus.Pending;
    }

    public enum ShipmentStatus
    {
        Pending,
        Shipped,
        InTransit,
        Delivered,
        Returned
    }
}
