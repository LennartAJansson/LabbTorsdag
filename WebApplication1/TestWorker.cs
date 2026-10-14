namespace WebApplication1;

using Customers.Features.Customers.Model;

using Employees.Features.Employees.Model;

using Messaging.Abstract;

using Microsoft.VisualBasic;

public class TestCustomerWorker(IMessaging<Customer> messaging, ILogger<TestCustomerWorker> logger) : BackgroundService
{
  protected override async Task ExecuteAsync(CancellationToken stoppingToken)
  {
    await messaging.Init();

    await foreach(Message<Customer> msg in messaging.ConsumeAsync(stoppingToken))
    {
      logger.LogInformation("Received {operation} of customer: {CustomerId}", msg.Type, msg.Payload.Id);
    }
  }
}

public class TestEmployeeWorker(IMessaging<Employee> messaging, ILogger<TestEmployeeWorker> logger) : BackgroundService
{
  protected override async Task ExecuteAsync(CancellationToken stoppingToken)
  {
    await messaging.Init();

    await foreach(Message<Employee> msg in messaging.ConsumeAsync(stoppingToken))
    {
      logger.LogInformation("Received {operation} of employee: {EmployeeId}", msg.Type, msg.Payload.Id);
    }
  }
}
