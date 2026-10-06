namespace WebApplication1.Features.Customers.UpdateCustomer;

using WebApplication1.Core;
using WebApplication1.Features.Customers.Core;

public sealed class UpdateCustomerEndpoint
  : IEndpoint
{
  public IEndpointRouteBuilder SetupEndpoint(IEndpointRouteBuilder endpoints)
  {
    endpoints.MapPut("/", async (UpdateCustomerRequest request, IRequestHandler<UpdateCustomerRequest, UpdateCustomerResponse> handler) =>
    {
      var result = await handler.HandleAsync(request);
      return result.ToMinimalApiResult(error => Results.BadRequest(new { error }));
    })
    .WithName("UpdateCustomer");
    return endpoints;
  }
}
