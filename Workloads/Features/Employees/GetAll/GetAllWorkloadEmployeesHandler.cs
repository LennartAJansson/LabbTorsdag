namespace Workloads.Features.Employees.GetAll;

using Common;
using FastEndpoints;

internal sealed class GetAllWorkloadEmployeesHandler(GetAllWorkloadEmployeesMapper mapper, IGetAllWorkloadEmployeesService service)
  : ICommandHandler<GetAllWorkloadEmployeesRequest, Result<GetAllWorkloadEmployeesResponse>>
{
  public async Task<Result<GetAllWorkloadEmployeesResponse>> ExecuteAsync(GetAllWorkloadEmployeesRequest command, CancellationToken ct)
    => Result.Success(mapper.FromEntity(await service.GetAllEmployeesAsync(ct)));
}
