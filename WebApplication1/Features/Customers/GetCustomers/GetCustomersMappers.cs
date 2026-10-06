namespace WebApplication1.Features.Customers.GetCustomers;

using WebApplication1.Features.Customers.Model;

public static class GetCustomersMappers
{
  extension(IEnumerable<Customer> customers)
  {
    public GetCustomersResponse ToGetAllCustomersResponse() => new GetCustomersResponse(customers.Select(customer => new GetCustomersResponse(
      customer.Id,
      customer.CompanyName
    )));
  }
}
