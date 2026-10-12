namespace Employees.Features.Employees.UpdateEmployee;

using Common;

using FastEndpoints;

internal sealed class UpdateEmployeeHandler(UpdateEmployeeMapper mapper, IUpdateEmployeeService service)
  : ICommandHandler<UpdateEmployeeRequest, Result<UpdateEmployeeResponse>>
{
  public async Task<Result<UpdateEmployeeResponse>> ExecuteAsync(UpdateEmployeeRequest command, CancellationToken ct)
  {
    var employee = mapper.ToEntity(command);
    var updated = await service.UpdateEmployeeAsync(employee, ct);
    if (updated is null)
    {
      return Result.Failure<UpdateEmployeeResponse>($"Employee with id '{command.Id}' was not found.");
    }

    return Result.Success(mapper.FromEntity(updated));
  }
}
