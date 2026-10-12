namespace GetEmployee;

using FastEndpoints;

internal sealed class GetEmployeeHandler(GetEmployeeMapper mapper, IGetEmployeeService service)
  : ICommandHandler<GetEmployeeRequest, GetEmployeeResponse>
{
  public async Task<GetEmployeeResponse> ExecuteAsync(GetEmployeeRequest command, CancellationToken ct)
  {
    var employee = await service.GetEmployeeAsync(command.Id, ct)
      ?? throw new InvalidOperationException($"Employee with id '{command.Id}' was not found.");

    return mapper.FromEntity(employee);
  }
}
