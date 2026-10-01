namespace WebApplication1.Extensions;

using WebApplication1.Contract;
using WebApplication1.Domain.Extensions;
using WebApplication1.Domain.Services;

public static class EndpointExtensions
{
  extension(IEndpointRouteBuilder app)
  {
    public IEndpointRouteBuilder MapEndpoints()
    {
      var group = app.MapGroup("/customers");

      group.MapPost("/", async (CreateCustomerRequest request, ICustomerCreateService customerService) =>
      {
        return (await customerService.Create(request.ToCustomer()))?.ToCreateCustomerResponse();
      })
      .WithName("CreateCustomer");

      group.MapPut("/", async (UpdateCustomerRequest request, ICustomerUpdateService customerService) =>
      {
        return (await customerService.Update(request.ToCustomer()))?.ToUpdateCustomerResponse();
      })
      .WithName("UpdateCustomer");

      group.MapDelete("/{id}", async (Guid id, ICustomerDeleteService customerService) =>
      {
        return (await customerService.Delete(id))?.ToDeleteCustomerResponse();
      })
      .WithName("DeleteCustomer");

      group.MapGet("/", async (ICustomerReadService customerService) =>
      {
        return (await customerService.Get())?.ToGetCustomersResponse();
      })
      .WithName("GetCustomers");

      group.MapGet("/{id}", async (Guid id, ICustomerReadService customerService) =>
      {
        return (await customerService.GetById(id))?.ToGetCustomerResponse();
      })
      .WithName("GetCustomerById");

      return app;
    }
  }
}
