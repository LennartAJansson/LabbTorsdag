namespace Employees.Features.Employees.DeleteEmployee;

using Common;

using FastEndpoints;

internal sealed class DeleteEmployeeHandler(DeleteEmployeeMapper mapper, IDeleteEmployeeService service)
  : ICommandHandler<DeleteEmployeeRequest, Result<DeleteEmployeeResponse>>
{
  public async Task<Result<DeleteEmployeeResponse>> ExecuteAsync(DeleteEmployeeRequest command, CancellationToken ct)
  {
    var employee = await service.DeleteEmployeeAsync(command.Id, ct);
    if (employee is null)
    {
      return Result.Failure<DeleteEmployeeResponse>($"Employee with id '{command.Id}' was not found.");
    }

    return Result.Success(mapper.FromEntity(employee));
  }
}
