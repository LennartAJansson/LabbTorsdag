namespace Customers.Features.Customers.GetAllCustomers;

using Customers.Core;

using Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Http;

public class GetAllCustomersEndpoint
  : IEndpoint
{
  public IEndpointRouteBuilder SetupEndpoint(IEndpointRouteBuilder endpoints)
  {
    endpoints.MapGet("/", async (IRequestHandler<GetAllCustomersRequest, GetAllCustomersResponse> handler) =>
    {
      var result = await handler.HandleAsync(new GetAllCustomersRequest());
      return result.ToMinimalApiResult(error => Results.BadRequest(new { error }));
    })
    .WithName("GetAllCustomers");
    return endpoints;
  }
}
