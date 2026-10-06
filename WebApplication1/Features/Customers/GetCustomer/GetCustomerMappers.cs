namespace WebApplication1.Features.Customers.GetCustomer;

using WebApplication1.Features.Customers.Model;

public static class GetCustomerMappers
{

  extension(Customer customer)
  {
    public GetCustomerResponse ToGetCustomerResponse() => new GetCustomerResponse(
      customer.Id,
      customer.CompanyName
    );
  }
}
