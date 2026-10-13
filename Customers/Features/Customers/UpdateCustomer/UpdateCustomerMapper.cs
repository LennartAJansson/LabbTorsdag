namespace Customers.Features.Customers.UpdateCustomer;

using global::Customers.Features.Customers.Model;

public static class  UpdateCustomerMapper
{
  extension(UpdateCustomerRequest request)
  {
    public Customer ToCustomer() => new Customer
    {
      Id = request.Id,
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
    public UpdateCustomerResponse ToUpdateCustomerResponse() => new UpdateCustomerResponse(
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