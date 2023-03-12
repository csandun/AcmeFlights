using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Domain.Aggregates.OrderAggregate;

public record OrderConfirmNotification(Order Order) : INotification;

public class OrderConfirmationNotificationHandler:  INotificationHandler<OrderConfirmNotification>
{
    
    public Task Handle(OrderConfirmNotification notification, CancellationToken cancellationToken)
    {
        // publish a notification using any massage broker like Kafka/RabbitMQ/AzureServiceBus.
        
        // Customer can notify this event from the customer consumer app 

        
        Console.WriteLine($"Order is confirmed : order id is ${notification.Order.Id}");

        
        return Task.CompletedTask;
    }
}
    
