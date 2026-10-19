namespace Workloads.Features.Workloads.Start;

using FastEndpoints;

internal sealed class StartWorkloadEndpoint : Endpoint<StartWorkloadRequest, WorkloadResponse, StartWorkloadMapper>
{
  public override void Configure()
  {
    Post("workload");
    AllowAnonymous();
  }

  public override async Task HandleAsync(StartWorkloadRequest request, CancellationToken cancellationToken)
  {
    var result = await request.ExecuteAsync(cancellationToken);
    if (result.IsFailure)
    {
      AddError(result.Error!);
      await Send.ErrorsAsync(400, cancellationToken);
      return;
    }

    await Send.OkAsync(result.Value, cancellationToken);
  }
}
