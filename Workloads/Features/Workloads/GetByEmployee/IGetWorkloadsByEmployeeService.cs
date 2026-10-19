namespace Workloads.Features.Workloads.GetByEmployee;

using global::Workloads.Features.Model;

public interface IGetWorkloadsByEmployeeService
{
  Task<IEnumerable<Workload>> GetWorkloadsByEmployeeAsync(Guid employeeId, CancellationToken cancellationToken);
}
