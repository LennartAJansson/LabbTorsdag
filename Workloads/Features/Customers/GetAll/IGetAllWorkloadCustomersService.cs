namespace Workloads.Features.Customers.GetAll;

using global::Workloads.Features.Model;

public interface IGetAllWorkloadCustomersService
{
  Task<IEnumerable<WorkloadCustomer>> GetAllCustomersAsync(CancellationToken cancellationToken);
}
