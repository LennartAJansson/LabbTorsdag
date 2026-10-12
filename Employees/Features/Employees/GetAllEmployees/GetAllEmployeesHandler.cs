namespace Employees.Features.Employees.GetAllEmployees;

using Common;

using FastEndpoints;

internal sealed class GetAllEmployeesHandler(GetAllEmployeesMapper mapper, IGetAllEmployeesService service)
  : ICommandHandler<GetAllEmployeesRequest, Result<GetAllEmployeesResponse>>
{
  public async Task<Result<GetAllEmployeesResponse>> ExecuteAsync(GetAllEmployeesRequest command, CancellationToken ct)
  {
    var employees = await service.GetAllEmployeesAsync(ct);
    return Result.Success(mapper.FromEntity(employees));
  }
}
