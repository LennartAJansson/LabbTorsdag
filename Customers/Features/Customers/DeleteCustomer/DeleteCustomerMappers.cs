namespace Customers.Features.Customers.DeleteCustomer;

using global::Customers.Features.Customers.Model;

public static class DeleteCustomerMappers
{
  extension(Customer customer)
  {
    public DeleteCustomerResponse ToDeleteCustomerResponse() => new DeleteCustomerResponse(
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