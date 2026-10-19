namespace Workloads.Features.Employees.GetAll;

using FastEndpoints;

internal sealed class GetAllWorkloadEmployeesEndpoint
  : EndpointWithoutRequest<GetAllWorkloadEmployeesResponse, GetAllWorkloadEmployeesMapper>
{
  public override void Configure()
  {
    Get("workloademployees");
    AllowAnonymous();
  }

  public override async Task HandleAsync(CancellationToken cancellationToken)
  {
    var result = await new GetAllWorkloadEmployeesRequest().ExecuteAsync(cancellationToken);
    await Send.OkAsync(result.Value, cancellationToken);
  }
}
