namespace DeleteEmployee;

using FastEndpoints;

internal sealed class DeleteEmployeeEndpoint
  : Endpoint<DeleteEmployeeRequest, DeleteEmployeeResponse, DeleteEmployeeMapper>
{
  public override void Configure()
  {
    Delete("employee/{Id}");
    AllowAnonymous();
  }

  public override async Task HandleAsync(DeleteEmployeeRequest request, CancellationToken cancellationToken)
  {
    DeleteEmployeeResponse response = await request.ExecuteAsync(cancellationToken);

    await Send.OkAsync(response, cancellationToken);
  }
}
