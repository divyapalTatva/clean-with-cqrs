using CleanCQRS.Application.Contributors.Order.Commands;
using CleanCQRS.Domain.Entities;
using CleanCQRS.Application.Abstractions;
using MediatR;

namespace CleanCQRS.Application.Contributors.Order.CommandHandlers
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Guid>
    {
        private readonly IOrderRepository _orderRepo;
        private readonly IProductRepository _productRepo;
        private readonly ICustomerRepository _customerRepo;

        public CreateOrderCommandHandler(
            IOrderRepository orderRepo,
            IProductRepository productRepo,
            ICustomerRepository customerRepo)
        {
            _orderRepo = orderRepo;
            _productRepo = productRepo;
            _customerRepo = customerRepo;
        }

        public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepo.GetByIdAsync(request.CustomerId, cancellationToken);
            if (customer == null)
                throw new ArgumentException($"Customer with Id {request.CustomerId} not found.");

            var order = new CleanCQRS.Domain.Entities.Order
            {
                CustomerId = customer.Id,
                OrderDate = DateTime.UtcNow,
                Status = OrderStatus.Pending
            };

            foreach (var item in request.Items)
            {
                var product = await _productRepo.GetByIdAsync(item.ProductId, cancellationToken);

                if (product == null)
                    throw new ArgumentException($"Product with Id {item.ProductId} not found.");

                order.AddOrderItem(product, item.Quantity);
            }

            await _orderRepo.AddAsync(order, cancellationToken);
            return order.Id;
        }
    }
}
