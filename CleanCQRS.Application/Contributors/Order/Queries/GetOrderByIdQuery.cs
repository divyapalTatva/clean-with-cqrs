using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCQRS.Application.Contributors.Order.Queries
{
    public class GetOrderByIdQuery : IRequest<OrderDto>
    {
        public Guid OrderId { get; set; }

        public GetOrderByIdQuery(Guid orderId)
        {
            OrderId = orderId;
        }
    }

    public class OrderDto
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; } = null!;
        public decimal TotalAmount { get; set; }
        public string Status { get; set; } = null!;
        public List<OrderItemDto> Items { get; set; } = new();
    }

    public class OrderItemDto
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
