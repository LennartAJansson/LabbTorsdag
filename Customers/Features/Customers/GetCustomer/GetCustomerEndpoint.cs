namespace Customers.Features.Customers.GetCustomer;

using Common;

using global::Customers.Features.Customers.Core;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

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
    .WithName("GetCustomer");
    return endpoints;
  }
}   