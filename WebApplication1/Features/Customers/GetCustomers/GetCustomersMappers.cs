namespace WebApplication1.Features.Customers.GetCustomers;

using WebApplication1.Features.Customers.GetCustomer;
using WebApplication1.Features.Customers.Model;

public static class GetCustomersMappers
{
  extension(IEnumerable<Customer> customers)
  {
    public IEnumerable<GetCustomerResponse> ToGetCustomersResponse() => customers.Select(customer => new GetCustomerResponse(
      customer.Id,
      customer.CompanyName
    ));
  }
}
