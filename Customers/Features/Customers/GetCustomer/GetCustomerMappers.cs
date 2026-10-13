namespace Customers.Features.Customers.GetCustomer;

using global::Customers.Features.Customers.Model;

public static class GetCustomerMappers
{

  extension(Customer customer)
  {
    public GetCustomerResponse ToGetCustomerResponse() => new GetCustomerResponse(
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
