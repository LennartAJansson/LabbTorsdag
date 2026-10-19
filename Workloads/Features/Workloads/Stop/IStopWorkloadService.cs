namespace Workloads.Features.Workloads.Stop;

using global::Workloads.Features.Model;

public interface IStopWorkloadService
{
  Task<Workload?> StopWorkloadAsync(Guid id, CancellationToken cancellationToken);
}
