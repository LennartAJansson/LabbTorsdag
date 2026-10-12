namespace DeleteEmployee;

using FastEndpoints;

internal sealed class DeleteEmployeeHandler(DeleteEmployeeMapper mapper, IDeleteEmployeeService service)
  : ICommandHandler<DeleteEmployeeRequest, DeleteEmployeeResponse>
{
  public async Task<DeleteEmployeeResponse> ExecuteAsync(DeleteEmployeeRequest command, CancellationToken ct)
  {
    var employee = await service.DeleteEmployeeAsync(command.Id, ct)
      ?? throw new InvalidOperationException($"Employee with id '{command.Id}' was not found.");

    return mapper.FromEntity(employee);
  }
}
