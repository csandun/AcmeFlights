using System;
using System.Threading.Tasks;
using Domain.SeedWork;

namespace Domain.Aggregates.OrderAggregate;

public interface IOrderRepository : IRepository<Order>
{
    Task AddAsync(Order order);

    void Update(Order order);

    Task<Order> GetAsync(Guid orderId);
}