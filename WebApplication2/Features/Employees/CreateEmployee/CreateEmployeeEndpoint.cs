namespace WebApplication2.Features.Employees.CreateEmployee;

using FastEndpoints;

internal sealed class CreateEmployeeEndpoint
  : Endpoint<CreateEmployeeRequest, CreateEmployeeResponse>
{
  public override void Configure()
  {
    Post("employee");
    AllowAnonymous();
  }

  public override async Task HandleAsync(CreateEmployeeRequest request, CancellationToken cancellationToken)
  {
    CreateEmployeeResponse response = await request.ExecuteAsync();

    _=await Send.OkAsync(response);
    //_=await Send.NotFoundAsync();
  }
}