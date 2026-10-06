namespace WebApplication1.Features.Customers.DeleteCustomer;

using WebApplication1.Features.Customers.Model;

public static class DeleteCustomerMappers
{
  extension(Customer customer)
  {
    public DeleteCustomerResponse ToDeleteCustomerResponse() => new DeleteCustomerResponse(
      customer.Id,
      customer.CompanyName
    );
  }
}