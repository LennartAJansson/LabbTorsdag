namespace Employees.Features.Employees.UpdateEmployee;

using Common;

using FastEndpoints;

using global::Employees.Features.Employees.Mappers;
using global::Employees.Features.Employees.Model;

using Messaging.Abstract;

internal sealed class UpdateEmployeeHandler(UpdateEmployeeMapper mapper, IUpdateEmployeeService service, IMessaging<EmployeeContract> messaging)
  : ICommandHandler<UpdateEmployeeRequest, Result<UpdateEmployeeResponse>>
{
  public async Task<Result<UpdateEmployeeResponse>> ExecuteAsync(UpdateEmployeeRequest command, CancellationToken ct)
  {
    var employee = await service.UpdateEmployeeAsync(mapper.ToEntity(command), ct);
    if (employee is null)
    {
      return Result.Failure<UpdateEmployeeResponse>($"Employee with id '{command.Id}' was not found.");
    }

    await messaging.PublishAsync(new Message<EmployeeContract>(MessageType.Update, employee.ToContract()), ct);
    return Result.Success(mapper.FromEntity(employee));
  }
}
