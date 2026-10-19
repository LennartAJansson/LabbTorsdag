namespace Workloads.Features.Workloads.GetByEmployee;

using FastEndpoints;

internal sealed class GetWorkloadsByEmployeeEndpoint
  : Endpoint<GetWorkloadsByEmployeeRequest, GetWorkloadsByEmployeeResponse, GetWorkloadsByEmployeeMapper>
{
  public override void Configure()
  {
    Get("workloads/employee/{EmployeeId:guid}");
    AllowAnonymous();
  }

  public override async Task HandleAsync(GetWorkloadsByEmployeeRequest request, CancellationToken cancellationToken)
  {
    var result = await request.ExecuteAsync(cancellationToken);
    await Send.OkAsync(result.Value, cancellationToken);
  }
}
