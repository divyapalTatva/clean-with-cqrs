using CleanCQRS.Application.Abstractions;
using CleanCQRS.Domain.Entities;
using CleanCQRS.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanCQRS.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _context;

        public CustomerRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Customer?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _context.Customers
                .Include(c => c.Orders)
                .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
        }
    }
}
