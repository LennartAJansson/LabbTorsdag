namespace Customers.Features.Customers.UpdateCustomer;

using Customers.Core;

using Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Http;

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
