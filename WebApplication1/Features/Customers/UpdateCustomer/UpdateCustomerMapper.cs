namespace WebApplication1.Features.Customers.UpdateCustomer;

using WebApplication1.Features.Customers.Model;

public static class  UpdateCustomerMapper
{
  extension(UpdateCustomerRequest request)
  {
    public Customer ToCustomer() => new Customer
    {
      Id = request.Id,
      CompanyName = request.CompanyName
    };
  }
  extension(Customer customer)
  {
    public UpdateCustomerResponse ToUpdateCustomerResponse() => new UpdateCustomerResponse(
      customer.Id,
      customer.CompanyName
    );
  }
}