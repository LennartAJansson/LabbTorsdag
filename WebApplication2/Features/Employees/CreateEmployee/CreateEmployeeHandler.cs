namespace WebApplication2.Features.Employees.CreateEmployee;

using FastEndpoints;

using WebApplication2.Features.Employees.Model;

internal sealed class CreateEmployeeHandler(CreateEmployeeMapper mapper, ICreateEmployeeService service)
  : ICommandHandler<CreateEmployeeRequest, CreateEmployeeResponse>
{
  public async Task<CreateEmployeeResponse> ExecuteAsync(CreateEmployeeRequest command, CancellationToken ct)
  {
    Employee employee = mapper.ToEntity(command);
    employee = await service.CreateEmployeeAsync(employee, ct);
    CreateEmployeeResponse response = mapper.FromEntity(employee);
    return response;
  }
}
