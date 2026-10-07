namespace Customers.Features.Customers.CreateCustomer;

using global::Customers.Features.Customers.Model;

public static class CreateCustomerMappers
{
  extension(CreateCustomerRequest request)
  {
    public Customer ToCustomer() => new Customer
    {
      CompanyName = request.CompanyName
    };  
  }
  extension(Customer customer)
  {
    public CreateCustomerResponse ToCreateCustomerResponse() => new CreateCustomerResponse(
      customer.Id,
      customer.CompanyName
    );
  }
}
