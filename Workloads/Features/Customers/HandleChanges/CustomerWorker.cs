using Messaging.Abstract;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using Workloads.Features.Model;

namespace Workloads.Features.Customers.HandleChanges;

public class CustomerWorker(ILogger<CustomerWorker> logger, IMessaging<CustomerContract> messaging, IServiceScopeFactory scopeFactory)
  : BackgroundService
{
  protected override async Task ExecuteAsync(CancellationToken stoppingToken)
  {
    await foreach(Message<CustomerContract> msg in messaging.ConsumeAsync(stoppingToken))
    {
      await using var scope = scopeFactory.CreateAsyncScope();
      var service = scope.ServiceProvider.GetRequiredService<ICustomerEventService>();
      WorkloadCustomer customer = new()
      {
        Id = msg.Payload.Id,
        CompanyName = msg.Payload.CompanyName
      };
      switch(msg.Type)
      {
        case MessageType.Create:
          await service.CreateCustomer(customer, stoppingToken);
          break;
        case MessageType.Update:
          await service.UpdateCustomer(customer, stoppingToken);
          break;
        case MessageType.Delete:
          await service.DeleteCustomer(customer, stoppingToken);
          break;
        default:
          throw new InvalidOperationException($"Unsupported customer message type '{msg.Type}'.");
      }
      logger.LogInformation("Received {operation} of customer: {CustomerId}", msg.Type, msg.Payload.Id);
    }
  }
}
