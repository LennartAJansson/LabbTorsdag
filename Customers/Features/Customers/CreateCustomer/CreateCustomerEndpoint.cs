namespace Customers.Features.Customers.CreateCustomer;

using Common;

using global::Customers.Features.Customers.Core;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

public sealed class CreateCustomerEndpoint
  : IEndpoint
{
  public IEndpointRouteBuilder SetupEndpoint(IEndpointRouteBuilder endpoints)
  {
    endpoints.MapPost("/", async (CreateCustomerRequest request, IRequestHandler<CreateCustomerRequest, CreateCustomerResponse> handler) =>
    {
      var result = await handler.HandleAsync(request);
      return result.ToMinimalApiResult(error => Results.BadRequest(new { error }));
    })
    .WithName("CreateCustomer");

    return endpoints;
  }
}
