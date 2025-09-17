using CleanCQRS.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace CleanCQRS.Application.Abstractions
{
    public interface IOrderRepository
    {
        Task<Order?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task AddAsync(Order order, CancellationToken cancellationToken);
        Task UpdateAsync(Order order, CancellationToken cancellationToken);
        Task DeleteAsync(Order order, CancellationToken cancellationToken);
    }

    public interface IProductRepository
    {
        Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    }

    public interface ICustomerRepository
    {
        Task<Customer?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    }

}
