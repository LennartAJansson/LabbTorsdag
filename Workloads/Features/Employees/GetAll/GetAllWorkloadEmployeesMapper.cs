namespace Workloads.Features.Employees.GetAll;

using FastEndpoints;
using global::Workloads.Features.Model;

internal sealed class GetAllWorkloadEmployeesMapper
  : Mapper<GetAllWorkloadEmployeesRequest, GetAllWorkloadEmployeesResponse, IEnumerable<WorkloadEmployee>>
{
  public override GetAllWorkloadEmployeesResponse FromEntity(IEnumerable<WorkloadEmployee> employees)
    => new(employees.Select(e => new WorkloadEmployeeResponse(e.Id, e.GivenName, e.Surname)).ToList());
}
