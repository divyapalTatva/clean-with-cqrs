using CleanCQRS.Application.Abstractions;
using CleanCQRS.Domain.Entities;
using CleanCQRS.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanCQRS.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _context;

        public OrderRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Order?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _context.Orders
                .Include(o => o.OrderItems)
                .Include(o => o.Customer)
                .FirstOrDefaultAsync(o => o.Id == id, cancellationToken);
        }

        public async Task AddAsync(Order order, CancellationToken cancellationToken)
        {
            await _context.Orders.AddAsync(order, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(Order order, CancellationToken cancellationToken)
        {
            _context.Orders.Update(order);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(Order order, CancellationToken cancellationToken)
        {
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
