namespace Workloads.Features.Employees.HandleChanges;

using System;
using System.Collections.Generic;
using System.Text;

using Workloads.Features.Model;

public interface IEmployeeEventService
{
  Task<WorkloadEmployee> CreateEmployee(WorkloadEmployee employee, CancellationToken cancellationToken = default);
  Task<WorkloadEmployee> UpdateEmployee(WorkloadEmployee employee, CancellationToken cancellationToken = default);
  Task<WorkloadEmployee> DeleteEmployee(WorkloadEmployee employee, CancellationToken cancellationToken = default);
}
