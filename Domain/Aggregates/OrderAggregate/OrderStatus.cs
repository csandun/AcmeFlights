namespace Domain.Aggregates.OrderAggregate;


/// <summary>
/// represents order status. If more and more status, we can use state machine to handle such of status.
/// </summary>
public enum OrderStatus
{
    Draft,
    Completed
}