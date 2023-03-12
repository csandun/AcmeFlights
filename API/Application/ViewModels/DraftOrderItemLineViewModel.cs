using System;

namespace API.Application.ViewModels;

public class OrderItemLineViewModel
{
    public Guid FlightId { get; set; }
    public Guid FlightRateId { get; set; }
    public int Quantity { get; set; }
}