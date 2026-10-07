namespace Customers.Features.Customers.Core;

using Microsoft.AspNetCore.Routing;

public interface IEndpoint
{
  IEndpointRouteBuilder SetupEndpoint(IEndpointRouteBuilder endpoints);
}
