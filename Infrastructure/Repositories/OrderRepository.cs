using System;
using System.Threading.Tasks;
using Domain.Aggregates.OrderAggregate;
using Domain.SeedWork;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly FlightsContext _context;

    public OrderRepository(FlightsContext context)
    {
        _context = context;
    }

    public IUnitOfWork UnitOfWork => _context;

    public Order Add(Order order)
    {
        return _context.Orders.Add(order).Entity;
    }

    public void Update(Order order)
    {
        _context.Orders.Update(order);
    }

    public async Task<Order> GetAsync(Guid orderId)
    {
        return await _context.Orders
            .Include(o => o.LineItems)
            .FirstOrDefaultAsync(o => o.Id == orderId);
    }
}