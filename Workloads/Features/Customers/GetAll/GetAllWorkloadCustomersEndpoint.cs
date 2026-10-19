namespace Workloads.Features.Customers.GetAll;

using FastEndpoints;

internal sealed class GetAllWorkloadCustomersEndpoint
  : EndpointWithoutRequest<GetAllWorkloadCustomersResponse, GetAllWorkloadCustomersMapper>
{
  public override void Configure()
  {
    Get("workloadcustomers");
    AllowAnonymous();
  }

  public override async Task HandleAsync(CancellationToken cancellationToken)
  {
    var result = await new GetAllWorkloadCustomersRequest().ExecuteAsync(cancellationToken);
    await Send.OkAsync(result.Value, cancellationToken);
  }
}
