namespace Employees.Features.Employees.DeleteEmployee;

using Common;

using FastEndpoints;

using global::Employees.Features.Employees.Model;

using Messaging.Abstract;

internal sealed class DeleteEmployeeHandler(DeleteEmployeeMapper mapper, IDeleteEmployeeService service, IMessaging<Employee> messaging)
  : ICommandHandler<DeleteEmployeeRequest, Result<DeleteEmployeeResponse>>
{
  public async Task<Result<DeleteEmployeeResponse>> ExecuteAsync(DeleteEmployeeRequest command, CancellationToken ct)
  {
    var employee = await service.DeleteEmployeeAsync(command.Id, ct);
    if (employee is null)
      return Result.Failure<DeleteEmployeeResponse>($"Employee with id '{command.Id}' was not found.");

    await messaging.PublishAsync(new Message<Employee>(MessageType.Delete, employee), ct);

    return Result.Success(mapper.FromEntity(employee));
  }
}
