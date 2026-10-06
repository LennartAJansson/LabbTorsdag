namespace WebApplication1.Features.Customers.DeleteCustomer;

using WebApplication1.Core;
using WebApplication1.Features.Customers.Core;

public class DeleteCustomerEndpoint
  : IEndpoint
{
  public IEndpointRouteBuilder SetupEndpoint(IEndpointRouteBuilder endpoints)
  {
    endpoints.MapDelete("/{id}", async (Guid id, IRequestHandler<DeleteCustomerRequest, DeleteCustomerResponse> handler) =>
    {
      var result = await handler.HandleAsync(new DeleteCustomerRequest(id));
      return result.ToMinimalApiResult(error => Results.NotFound(new { error }));
    })
    .WithName("DeleteCustomer");
    return endpoints;
  }
}
