using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCQRS.Application.Contributors.Order.Commands
{
    // Request DTO
    public class CreateOrderCommand : IRequest<Guid>
    {
        public Guid CustomerId { get; set; }
        public List<CreateOrderItemDto> Items { get; set; } = new();
    }

    public class CreateOrderItemDto
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
