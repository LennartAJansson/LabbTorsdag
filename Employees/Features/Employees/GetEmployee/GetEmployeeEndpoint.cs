namespace Employees.Features.Employees.GetEmployee;

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
    var result = await request.ExecuteAsync(cancellationToken);

    if (result.IsFailure)
    {
      await Send.NotFoundAsync(cancellationToken);
      return;
    }

    await Send.OkAsync(result.Value, cancellationToken);
  }
}
