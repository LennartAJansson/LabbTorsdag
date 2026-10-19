namespace Workloads.Features.Employees.GetAll;

using global::Workloads.Features.Model;

public interface IGetAllWorkloadEmployeesService
{
  Task<IEnumerable<WorkloadEmployee>> GetAllEmployeesAsync(CancellationToken cancellationToken);
}
