namespace WebApplication1.Features.Customers.GetCustomers;

using WebApplication1.Core;
using WebApplication1.Features.Customers.Core;

public class GetCustomersEndpoint
  : IEndpoint
{
  public IEndpointRouteBuilder SetupEndpoint(IEndpointRouteBuilder endpoints)
  {
    endpoints.MapGet("/", async (IRequestHandler<GetCustomersRequest, GetCustomersResponse> handler) =>
    {
      var result = await handler.HandleAsync(new GetCustomersRequest());
      return result.ToMinimalApiResult(error => Results.BadRequest(new { error }));
    })
    .WithName("GetCustomers");
    return endpoints;
  }
}
