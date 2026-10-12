namespace Employees.Features.Employees.GetAllEmployees;

using FastEndpoints;

internal sealed class GetAllEmployeesEndpoint
  : Endpoint<GetAllEmployeesRequest, GetAllEmployeesResponse, GetAllEmployeesMapper>
{
  public override void Configure()
  {
    Get("employees");
    AllowAnonymous();
  }

  public override async Task HandleAsync(GetAllEmployeesRequest request, CancellationToken cancellationToken)
  {
    var result = await request.ExecuteAsync(cancellationToken);

    await Send.OkAsync(result.Value, cancellationToken);
  }
}
