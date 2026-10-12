namespace UpdateEmployee;

using FastEndpoints;

internal sealed class UpdateEmployeeEndpoint
  : Endpoint<UpdateEmployeeRequest, UpdateEmployeeResponse, UpdateEmployeeMapper>
{
  public override void Configure()
  {
    Put("employee");
    AllowAnonymous();
  }

  public override async Task HandleAsync(UpdateEmployeeRequest request, CancellationToken cancellationToken)
  {
    UpdateEmployeeResponse response = await request.ExecuteAsync(cancellationToken);

    await Send.OkAsync(response, cancellationToken);
  }
}
