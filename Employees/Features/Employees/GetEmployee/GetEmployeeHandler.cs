namespace Employees.Features.Employees.GetEmployee;

using Common;

using FastEndpoints;

internal sealed class GetEmployeeHandler(GetEmployeeMapper mapper, IGetEmployeeService service)
  : ICommandHandler<GetEmployeeRequest, Result<GetEmployeeResponse>>
{
  public async Task<Result<GetEmployeeResponse>> ExecuteAsync(GetEmployeeRequest command, CancellationToken ct)
  {
    var employee = await service.GetEmployeeAsync(command.Id, ct);
    if (employee is null)
    {
      return Result.Failure<GetEmployeeResponse>($"Employee with id '{command.Id}' was not found.");
    }

    return Result.Success(mapper.FromEntity(employee));
  }
}
