namespace Workloads.Features.Workloads.Stop;

using Common;
using FastEndpoints;

internal sealed class StopWorkloadHandler(StopWorkloadMapper mapper, IStopWorkloadService service)
  : ICommandHandler<StopWorkloadRequest, Result<WorkloadResponse>>
{
  public async Task<Result<WorkloadResponse>> ExecuteAsync(StopWorkloadRequest command, CancellationToken ct)
  {
    var workload = await service.StopWorkloadAsync(command.Id, ct);
    return workload is null
      ? Result.Failure<WorkloadResponse>($"Workload with id '{command.Id}' was not found.")
      : Result.Success(mapper.FromEntity(workload));
  }
}
