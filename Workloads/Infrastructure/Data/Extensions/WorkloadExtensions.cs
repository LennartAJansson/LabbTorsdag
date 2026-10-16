namespace Workloads.Infrastructure.Data.Extensions;

using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Workloads.Features.Customers.HandleChanges;
using Workloads.Features.Employees.HandleChanges;
using Workloads.Infrastructure.Data.Services;

public static class WorkloadExtensions
{
  extension(IServiceCollection services)
  {
    public IServiceCollection AddWorkloadsData(IConfiguration configuration)
    {
      services.AddTransient<ICustomerEventService, WorkloadService>();
      services.AddTransient<IEmployeeEventService, WorkloadService>();
      return services;
    }
  }
}
