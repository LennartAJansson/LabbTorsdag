namespace Customers.Features.Customers.CreateCustomer;

using global::Customers.Features.Customers.Model;

public static class CreateCustomerMappers
{
  extension(CreateCustomerRequest request)
  {
    public Customer ToCustomer() => new Customer
    {
      CompanyName = request.CompanyName,
      OrganizationNumber = request.OrganizationNumber,
      ContactName = request.ContactName,
      Street = request.Street,
      PostalCode = request.PostalCode,
      City = request.City,
      Phone = request.Phone
    };  
  }
  extension(Customer customer)
  {
    public CreateCustomerResponse ToCreateCustomerResponse() => new CreateCustomerResponse(
      customer.Id,
      customer.CompanyName,
      customer.OrganizationNumber,
      customer.ContactName,
      customer.Street,
      customer.PostalCode,
      customer.City,
      customer.Phone
    );
  }
}
