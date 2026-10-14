namespace Employees.Features.Employees.CreateEmployee;

using Common;

using FastEndpoints;

using global::Employees.Features.Employees.Model;

using Messaging.Abstract;

internal sealed class CreateEmployeeHandler(CreateEmployeeMapper mapper, ICreateEmployeeService service, IMessaging<Employee> messaging)
  : ICommandHandler<CreateEmployeeRequest, Result<CreateEmployeeResponse>>
{
  public async Task<Result<CreateEmployeeResponse>> ExecuteAsync(CreateEmployeeRequest command, CancellationToken ct)
  {
    var employee = mapper.ToEntity(command);
    employee = await service.CreateEmployeeAsync(employee, ct);
    await messaging.PublishAsync(new Message<Employee>(MessageType.Create, employee), ct);
    return Result.Success(mapper.FromEntity(employee));
  }
}
