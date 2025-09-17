using CleanCQRS.Application.Abstractions;
using CleanCQRS.Application.Contributors.Order.Queries;
using MediatR;

namespace CleanCQRS.Application.Contributors.Order.QueryHandlers
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, OrderDto>
    {
        private readonly IOrderRepository _orderRepo;

        public GetOrderByIdQueryHandler(IOrderRepository orderRepo)
        {
            _orderRepo = orderRepo;
        }

        public async Task<OrderDto> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var order = await _orderRepo.GetByIdAsync(request.OrderId, cancellationToken);

            if (order == null)
                throw new KeyNotFoundException($"Order with Id {request.OrderId} not found.");

            return new OrderDto
            {
                Id = order.Id,
                CustomerId = order.CustomerId,
                CustomerName = $"{order.Customer.FirstName} {order.Customer.LastName}",
                TotalAmount = order.TotalAmount,
                Status = order.Status.ToString(),
                Items = order.OrderItems.Select(oi => new OrderItemDto
                {
                    ProductId = oi.ProductId,
                    Quantity = oi.Quantity,
                    UnitPrice = oi.UnitPrice
                }).ToList()
            };
        }
    }
}
