namespace Workloads.Features.Employees.HandleChanges;

using Messaging.Abstract;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using global::Workloads.Features.Model;

public class EmployeeWorker(ILogger<EmployeeWorker> logger, IMessaging<EmployeeContract> messaging, IServiceScopeFactory scopeFactory)
  : BackgroundService
{
  protected override async Task ExecuteAsync(CancellationToken stoppingToken)
  {
    await foreach (Message<EmployeeContract> msg in messaging.ConsumeAsync(stoppingToken))
    {
      await using var scope = scopeFactory.CreateAsyncScope();
      var service = scope.ServiceProvider.GetRequiredService<IEmployeeEventService>();
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
        default:
          throw new InvalidOperationException($"Unsupported employee message type '{msg.Type}'.");
      }
      logger.LogInformation("Received {operation} of employee: {EmployeeId}", msg.Type, msg.Payload.Id);
    }
  }
}
