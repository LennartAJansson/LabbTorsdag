namespace GetEmployee;

using FastEndpoints;

internal sealed class GetEmployeeEndpoint
  : Endpoint<GetEmployeeRequest, GetEmployeeResponse, GetEmployeeMapper>
{
  public override void Configure()
  {
    Get("employee/{Id}");
    AllowAnonymous();
  }

  public override async Task HandleAsync(GetEmployeeRequest request, CancellationToken cancellationToken)
  {
    GetEmployeeResponse response = await request.ExecuteAsync(cancellationToken);

    await Send.OkAsync(response, cancellationToken);
  }
}
