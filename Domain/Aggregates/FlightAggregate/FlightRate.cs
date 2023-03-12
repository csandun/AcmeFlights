using Domain.Common;
using Domain.SeedWork;

namespace Domain.Aggregates.FlightAggregate;

public class FlightRate : Entity
{
    protected FlightRate()
    {
    }

    public FlightRate(string name, Price price, int available)
    {
        Name = name;
        Price = price;
        Available = available;
    }

    public string Name { get; }
    public Price Price { get; private set; }
    public int Available { get; private set; }

    public void ChangePrice(Price price)
    {
        Price = price;
    }

    public void MutateAvailability(int quantity)
    {
        Available += quantity;
    }
}