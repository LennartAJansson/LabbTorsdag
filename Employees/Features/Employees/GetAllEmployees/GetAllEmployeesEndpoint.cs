namespace Employees.Features.Employees.GetAllEmployees;

using FastEndpoints;

internal sealed class GetAllEmployeesEndpoint
  : EndpointWithoutRequest<GetAllEmployeesResponse, GetAllEmployeesMapper>
{
  public override void Configure()
  {
    Get("employees");
    AllowAnonymous();
  }

  public override async Task HandleAsync(CancellationToken cancellationToken)
  {
    var result = await new GetAllEmployeesRequest().ExecuteAsync(cancellationToken);

    await Send.OkAsync(result.Value, cancellationToken);
  }
}
