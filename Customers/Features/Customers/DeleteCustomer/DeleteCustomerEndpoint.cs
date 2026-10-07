namespace Customers.Features.Customers.DeleteCustomer;

using Customers.Core;

using Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Http;

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
