namespace UpdateEmployee;

using FastEndpoints;

internal sealed class UpdateEmployeeHandler(UpdateEmployeeMapper mapper, IUpdateEmployeeService service)
  : ICommandHandler<UpdateEmployeeRequest, UpdateEmployeeResponse>
{
  public async Task<UpdateEmployeeResponse> ExecuteAsync(UpdateEmployeeRequest command, CancellationToken ct)
  {
    var employee = mapper.ToEntity(command);
    var updated = await service.UpdateEmployeeAsync(employee, ct)
      ?? throw new InvalidOperationException($"Employee with id '{command.Id}' was not found.");

    return mapper.FromEntity(updated);
  }
}
