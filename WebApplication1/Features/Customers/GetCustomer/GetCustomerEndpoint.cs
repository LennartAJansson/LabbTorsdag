namespace WebApplication1.Features.Customers.GetCustomer;

using WebApplication1.Core;
using WebApplication1.Features.Customers.Core;

public class GetCustomerEndpoint
  : IEndpoint
{
  public IEndpointRouteBuilder SetupEndpoint(IEndpointRouteBuilder endpoints)
  {
    endpoints.MapGet("/{id}", async (Guid id, IRequestHandler<GetCustomerRequest, GetCustomerResponse> handler) =>
    {
      var result = await handler.HandleAsync(new GetCustomerRequest(id));
      return result.ToMinimalApiResult(error => Results.NotFound(new { error }));
    })
    .WithName("GetCustomerById");
    return endpoints;
  }
}   