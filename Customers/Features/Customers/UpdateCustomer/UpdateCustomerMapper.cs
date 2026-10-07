namespace Customers.Features.Customers.UpdateCustomer;

using global::Customers.Features.Customers.Model;

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