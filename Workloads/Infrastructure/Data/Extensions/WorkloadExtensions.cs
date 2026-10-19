namespace Workloads.Infrastructure.Data.Extensions;

using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Workloads.Features.Customers.GetAll;
using Workloads.Features.Customers.HandleChanges;
using Workloads.Features.Employees.GetAll;
using Workloads.Features.Employees.HandleChanges;
using Workloads.Features.Workloads.GetByCustomer;
using Workloads.Features.Workloads.GetByEmployee;
using Workloads.Features.Workloads.Start;
using Workloads.Features.Workloads.Stop;
using Workloads.Infrastructure.Data.Context;
using Workloads.Infrastructure.Data.Services;

public static class WorkloadExtensions
{
  extension(IServiceCollection services)
  {
    public IServiceCollection AddWorkloadsData(IConfiguration configuration)
    {
      var connectionString = configuration.GetConnectionString("WorkloadsConnection")
        ?? throw new InvalidOperationException("Connection string 'WorkloadsConnection' is required.");
      services.AddDbContext<WorkloadContext>(options => options.UseSqlServer(connectionString));

      services.AddScoped<ICustomerEventService, WorkloadService>();
      services.AddScoped<IEmployeeEventService, WorkloadService>();
      services.AddScoped<IGetAllWorkloadCustomersService, WorkloadService>();
      services.AddScoped<IGetAllWorkloadEmployeesService, WorkloadService>();
      services.AddScoped<IStartWorkloadService, WorkloadService>();
      services.AddScoped<IStopWorkloadService, WorkloadService>();
      services.AddScoped<IGetWorkloadsByCustomerService, WorkloadService>();
      services.AddScoped<IGetWorkloadsByEmployeeService, WorkloadService>();
      return services;
    }
  }

  extension(WebApplication app)
  {
    public WebApplication UseWorkloadsData()
    {
      using var scope = app.Services.CreateScope();
      var context = scope.ServiceProvider.GetRequiredService<WorkloadContext>();
      if (context.Database.GetPendingMigrations().Any())
        context.Database.Migrate();

      return app;
    }
  }
}
