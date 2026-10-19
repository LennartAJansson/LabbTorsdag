namespace Workloads.Features.Workloads.GetByEmployee;

using Common;
using FastEndpoints;

internal sealed class GetWorkloadsByEmployeeHandler(GetWorkloadsByEmployeeMapper mapper, IGetWorkloadsByEmployeeService service)
  : ICommandHandler<GetWorkloadsByEmployeeRequest, Result<GetWorkloadsByEmployeeResponse>>
{
  public async Task<Result<GetWorkloadsByEmployeeResponse>> ExecuteAsync(GetWorkloadsByEmployeeRequest command, CancellationToken ct)
    => Result.Success(mapper.FromEntity(await service.GetWorkloadsByEmployeeAsync(command.EmployeeId, ct)));
}
