namespace Workloads.Infrastructure.Data.Services;

using System;
using System.Collections.Generic;
using System.Text;

using Workloads.Features.Customers.HandleChanges;
using Workloads.Features.Employees.HandleChanges;
using Workloads.Features.Model;

internal class WorkloadService : ICustomerEventService, IEmployeeEventService
{
  public Task<WorkloadCustomer> CreateCustomer(WorkloadCustomer customer, CancellationToken cancellationToken = default)
  {
    throw new NotImplementedException();
  }

  public Task<WorkloadEmployee> CreateEmployee(WorkloadEmployee employee, CancellationToken cancellationToken = default)
  {
    throw new NotImplementedException();
  }

  public Task<WorkloadCustomer> DeleteCustomer(WorkloadCustomer customer, CancellationToken cancellationToken = default)
  {
    throw new NotImplementedException();
  }

  public Task<WorkloadEmployee> DeleteEmployee(WorkloadEmployee employee, CancellationToken cancellationToken = default)
  {
    throw new NotImplementedException();
  }

  public Task<WorkloadCustomer> UpdateCustomer(WorkloadCustomer customer, CancellationToken cancellationToken = default)
  {
    throw new NotImplementedException();
  }

  public Task<WorkloadEmployee> UpdateEmployee(WorkloadEmployee employee, CancellationToken cancellationToken = default)
  {
    throw new NotImplementedException();
  }
}
