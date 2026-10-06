namespace WebApplication1.Features.Customers.GetCustomers;

using WebApplication1.Core;
using WebApplication1.Features.Customers.Core;
using WebApplication1.Features.Customers.GetCustomer;

public class GetCustomersEndpoint
  : IEndpoint
{
  public IEndpointRouteBuilder SetupEndpoint(IEndpointRouteBuilder endpoints)
  {
    endpoints.MapGet("/", async (IRequestHandler<GetAllCustomersRequest, IEnumerable<GetCustomerResponse>> handler) =>
    {
      var result = await handler.HandleAsync(new GetAllCustomersRequest());
      return result.ToMinimalApiResult(error => Results.BadRequest(new { error }));
    })
    .WithName("GetCustomers");
    return endpoints;
  }
}
