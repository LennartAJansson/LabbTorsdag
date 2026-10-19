namespace Workloads.Features.Customers.HandleChanges;

using System;
using System.Collections.Generic;
using System.Text;

using global::Workloads.Features.Model;

public interface ICustomerEventService
{
  Task<WorkloadCustomer> CreateCustomer(WorkloadCustomer customer, CancellationToken cancellationToken = default);
  Task<WorkloadCustomer> UpdateCustomer(WorkloadCustomer customer, CancellationToken cancellationToken = default);
  Task<WorkloadCustomer> DeleteCustomer(WorkloadCustomer customer, CancellationToken cancellationToken = default);
}
