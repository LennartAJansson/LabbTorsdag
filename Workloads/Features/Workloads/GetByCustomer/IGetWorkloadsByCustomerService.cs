namespace Workloads.Features.Workloads.GetByCustomer;

using global::Workloads.Features.Model;

public interface IGetWorkloadsByCustomerService
{
  Task<IEnumerable<Workload>> GetWorkloadsByCustomerAsync(Guid customerId, CancellationToken cancellationToken);
}
