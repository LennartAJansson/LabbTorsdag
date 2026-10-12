namespace GetAllEmployees;

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
    GetAllEmployeesResponse response = await request.ExecuteAsync(cancellationToken);

    await Send.OkAsync(response, cancellationToken);
  }
}
