namespace Employees.Features.Employees.UpdateEmployee;

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
    var result = await request.ExecuteAsync(cancellationToken);

    if (result.IsFailure)
    {
      await Send.NotFoundAsync(cancellationToken);
      return;
    }

    await Send.OkAsync(result.Value, cancellationToken);
  }
}
