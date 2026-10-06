namespace WebApplication1.Features.Customers.CreateCustomer;

using WebApplication1.Core;
using WebApplication1.Features.Customers.Core;

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
