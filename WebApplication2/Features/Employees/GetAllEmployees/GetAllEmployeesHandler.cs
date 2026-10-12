namespace GetAllEmployees;

using FastEndpoints;

internal sealed class GetAllEmployeesHandler(GetAllEmployeesMapper mapper, IGetAllEmployeesService service)
  : ICommandHandler<GetAllEmployeesRequest, GetAllEmployeesResponse>
{
  public async Task<GetAllEmployeesResponse> ExecuteAsync(GetAllEmployeesRequest command, CancellationToken ct)
  {
    var employees = await service.GetAllEmployeesAsync(ct);
    return mapper.FromEntity(employees);
  }
}
