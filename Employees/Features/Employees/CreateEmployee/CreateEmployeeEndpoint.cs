namespace Employees.Features.Employees.CreateEmployee;

using FastEndpoints;

internal sealed class CreateEmployeeEndpoint
  : Endpoint<CreateEmployeeRequest, CreateEmployeeResponse, CreateEmployeeMapper>
{
  public override void Configure()
  {
    Post("employee");
    AllowAnonymous();
  }

  public override async Task HandleAsync(CreateEmployeeRequest request, CancellationToken cancellationToken)
  {
    var result = await request.ExecuteAsync(cancellationToken);

    if (result.IsFailure)
    {
      await Send.ErrorsAsync(400, cancellationToken);
      return;
    }

    await Send.OkAsync(result.Value, cancellationToken);
  }
}
