namespace Workloads.Features.Customers.GetAll;

using FastEndpoints;
using global::Workloads.Features.Model;

internal sealed class GetAllWorkloadCustomersMapper
  : Mapper<GetAllWorkloadCustomersRequest, GetAllWorkloadCustomersResponse, IEnumerable<WorkloadCustomer>>
{
  public override GetAllWorkloadCustomersResponse FromEntity(IEnumerable<WorkloadCustomer> customers)
    => new(customers.Select(c => new WorkloadCustomerResponse(c.Id, c.CompanyName)).ToList());
}
