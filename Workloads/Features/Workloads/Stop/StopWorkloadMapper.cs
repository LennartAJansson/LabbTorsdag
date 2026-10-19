namespace Workloads.Features.Workloads.Stop;

using FastEndpoints;
using global::Workloads.Features.Model;

internal sealed class StopWorkloadMapper : Mapper<StopWorkloadRequest, WorkloadResponse, Workload>
{
  public override WorkloadResponse FromEntity(Workload workload)
    => WorkloadResponse.FromEntity(workload);
}
