using Messaging.Abstract;

using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using Workloads.Features.Model;

namespace Workloads.Features.Customers.HandleChanges;

public class CustomerWorker(ILogger<CustomerWorker> logger, IMessaging<CustomerContract> messaging, ICustomerEventService service) 
  : BackgroundService
{
  protected override async Task ExecuteAsync(CancellationToken stoppingToken)
  {
    await foreach(Message<CustomerContract> msg in messaging.ConsumeAsync(stoppingToken))
    {
      // DO NOT CALL INIT() HERE, IT WILL BE CALLED AUTOMATICALLY WHEN THE FIRST MESSAGE IS GOINT TO BE SENT
      WorkloadCustomer customer = new()
      {
        Id = msg.Payload.Id,
        CompanyName = msg.Payload.CompanyName
      };
      switch(msg.Type)
      {
        case MessageType.Create:
          await service.CreateCustomer(customer);
          break;
        case MessageType.Update:
          await service.UpdateCustomer(customer);
          break;
        case MessageType.Delete:
          await service.DeleteCustomer(customer);
          break;
      }
      logger.LogInformation("Received {operation} of customer: {CustomerId}", msg.Type, msg.Payload.Id);
    }
  }
}
