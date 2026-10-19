namespace Workloads.Features.Workloads.GetByCustomer;

using FastEndpoints;

internal sealed class GetWorkloadsByCustomerEndpoint
  : Endpoint<GetWorkloadsByCustomerRequest, GetWorkloadsByCustomerResponse, GetWorkloadsByCustomerMapper>
{
  public override void Configure()
  {
    Get("workloads/customer/{CustomerId:guid}");
    AllowAnonymous();
  }

  public override async Task HandleAsync(GetWorkloadsByCustomerRequest request, CancellationToken cancellationToken)
  {
    var result = await request.ExecuteAsync(cancellationToken);
    await Send.OkAsync(result.Value, cancellationToken);
  }
}
