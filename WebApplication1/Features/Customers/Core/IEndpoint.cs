namespace WebApplication1.Features.Customers.Core;

public interface IEndpoint
{
  IEndpointRouteBuilder SetupEndpoint(IEndpointRouteBuilder endpoints);
}
