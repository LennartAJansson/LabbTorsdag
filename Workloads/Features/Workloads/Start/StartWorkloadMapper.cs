namespace Workloads.Features.Workloads.Start;

using FastEndpoints;
using global::Workloads.Features.Model;

internal sealed class StartWorkloadMapper : Mapper<StartWorkloadRequest, WorkloadResponse, Workload>
{
  public override Workload ToEntity(StartWorkloadRequest request)
    => new()
    {
      CustomerId = request.CustomerId,
      EmployeeId = request.EmployeeId,
      Start = DateTimeOffset.UtcNow,
      Notes = request.Notes
    };

  public override WorkloadResponse FromEntity(Workload workload)
    => WorkloadResponse.FromEntity(workload);
}
