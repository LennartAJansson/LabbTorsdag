namespace Workloads.Features.Workloads.GetByEmployee;

using FastEndpoints;
using global::Workloads.Features.Model;

internal sealed class GetWorkloadsByEmployeeMapper
  : Mapper<GetWorkloadsByEmployeeRequest, GetWorkloadsByEmployeeResponse, IEnumerable<Workload>>
{
  public override GetWorkloadsByEmployeeResponse FromEntity(IEnumerable<Workload> workloads)
    => new(workloads.Select(WorkloadResponse.FromEntity).ToList());
}
