namespace Employees.Features.Employees.CreateEmployee;

using Common;

using FastEndpoints;

internal sealed class CreateEmployeeHandler(CreateEmployeeMapper mapper, ICreateEmployeeService service)
  : ICommandHandler<CreateEmployeeRequest, Result<CreateEmployeeResponse>>
{
  public async Task<Result<CreateEmployeeResponse>> ExecuteAsync(CreateEmployeeRequest command, CancellationToken ct)
  {
    var employee = mapper.ToEntity(command);
    employee = await service.CreateEmployeeAsync(employee, ct);
    return Result.Success(mapper.FromEntity(employee));
  }
}
