using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCQRS.Domain.Entities
{
    public class Payment
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid OrderId { get; set; }
        public Order Order { get; set; } = null!;

        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; } = DateTime.UtcNow;
        public PaymentStatus Status { get; set; } = PaymentStatus.Pending;
        public string TransactionId { get; set; } = null!;
    }

    public enum PaymentStatus
    {
        Pending,
        Completed,
        Failed,
        Refunded
    }
}
