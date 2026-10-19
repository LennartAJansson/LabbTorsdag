namespace Workloads.Features.Workloads.Start;

using Common;
using FastEndpoints;

internal sealed class StartWorkloadHandler(StartWorkloadMapper mapper, IStartWorkloadService service)
  : ICommandHandler<StartWorkloadRequest, Result<WorkloadResponse>>
{
  public async Task<Result<WorkloadResponse>> ExecuteAsync(StartWorkloadRequest command, CancellationToken ct)
  {
    var workload = await service.StartWorkloadAsync(mapper.ToEntity(command), ct);
    return workload is null
      ? Result.Failure<WorkloadResponse>("Customer or employee was not found in the active workload projections.")
      : Result.Success(mapper.FromEntity(workload));
  }
}
