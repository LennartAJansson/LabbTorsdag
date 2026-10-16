namespace Workloads.Features.Employees.HandleChanges;

using Messaging.Abstract;

using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using Workloads.Features.Model;

public class EmployeeWorker(ILogger<EmployeeWorker> logger, IMessaging<EmployeeContract> messaging, IEmployeeEventService service) 
  : BackgroundService
{
  protected override async Task ExecuteAsync(CancellationToken stoppingToken)
  {
    // DO NOT CALL INIT() HERE, IT WILL BE CALLED AUTOMATICALLY WHEN THE FIRST MESSAGE IS GOINT TO BE SENT
    await foreach (Message<EmployeeContract> msg in messaging.ConsumeAsync(stoppingToken))
    {
      WorkloadEmployee employee = new()
      {
        Id = msg.Payload.Id,
        GivenName = msg.Payload.GivenName,
        Surname = msg.Payload.Surname,
      };
      switch (msg.Type)
      {
        case MessageType.Create:
          await service.CreateEmployee(employee, stoppingToken);
          break;
        case MessageType.Update:
          await service.UpdateEmployee(employee, stoppingToken);
          break;
        case MessageType.Delete:
          await service.DeleteEmployee(employee, stoppingToken);
          break;
      }
      logger.LogInformation("Received {operation} of employee: {EmployeeId}", msg.Type, msg.Payload.Id);
    }
  }
}
