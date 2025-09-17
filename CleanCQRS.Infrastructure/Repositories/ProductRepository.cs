using CleanCQRS.Application.Abstractions;
using CleanCQRS.Domain.Entities;
using CleanCQRS.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanCQRS.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _context.Products
                .Include(p => p.OrderItems)
                .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
        }
    }
}
