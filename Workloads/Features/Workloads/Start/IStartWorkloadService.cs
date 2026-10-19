namespace Workloads.Features.Workloads.Start;

using global::Workloads.Features.Model;

public interface IStartWorkloadService
{
  Task<Workload?> StartWorkloadAsync(Workload workload, CancellationToken cancellationToken);
}
