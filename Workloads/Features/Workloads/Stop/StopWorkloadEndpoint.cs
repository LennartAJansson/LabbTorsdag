namespace Workloads.Features.Workloads.Stop;

using FastEndpoints;

internal sealed class StopWorkloadEndpoint : Endpoint<StopWorkloadRequest, WorkloadResponse, StopWorkloadMapper>
{
  public override void Configure()
  {
    Put("workload/{Id:guid}/stop");
    AllowAnonymous();
  }

  public override async Task HandleAsync(StopWorkloadRequest request, CancellationToken cancellationToken)
  {
    var result = await request.ExecuteAsync(cancellationToken);
    if (result.IsFailure)
    {
      await Send.NotFoundAsync(cancellationToken);
      return;
    }

    await Send.OkAsync(result.Value, cancellationToken);
  }
}
