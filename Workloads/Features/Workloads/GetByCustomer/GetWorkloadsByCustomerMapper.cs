namespace Workloads.Features.Workloads.GetByCustomer;

using FastEndpoints;
using global::Workloads.Features.Model;

internal sealed class GetWorkloadsByCustomerMapper
  : Mapper<GetWorkloadsByCustomerRequest, GetWorkloadsByCustomerResponse, IEnumerable<Workload>>
{
  public override GetWorkloadsByCustomerResponse FromEntity(IEnumerable<Workload> workloads)
    => new(workloads.Select(WorkloadResponse.FromEntity).ToList());
}
