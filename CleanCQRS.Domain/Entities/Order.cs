using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCQRS.Domain.Entities
{
    public class Order
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;

        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public decimal TotalAmount { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Pending;

        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

        // Business logic
        public void AddOrderItem(Product product, int quantity)
        {
            if (quantity <= 0)
                throw new ArgumentException("Quantity must be greater than zero.");

            var orderItem = new OrderItem
            {
                ProductId = product.Id,
                Product = product,
                Quantity = quantity,
                UnitPrice = product.Price
            };

            OrderItems.Add(orderItem);
            TotalAmount = OrderItems.Sum(i => i.Quantity * i.UnitPrice);
        }
    }

    public enum OrderStatus
    {
        Pending,
        Processing,
        Shipped,
        Delivered,
        Cancelled
    }
}
