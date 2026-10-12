namespace Employees.Features.Employees.DeleteEmployee;

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
    var result = await request.ExecuteAsync(cancellationToken);

    if (result.IsFailure)
    {
      await Send.NotFoundAsync(cancellationToken);
      return;
    }

    await Send.OkAsync(result.Value, cancellationToken);
  }
}
