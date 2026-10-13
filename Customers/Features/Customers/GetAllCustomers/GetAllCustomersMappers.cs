namespace Customers.Features.Customers.GetAllCustomers;

using global::Customers.Features.Customers.Model;

public static class GetAllCustomersMappers
{
  extension(IEnumerable<Customer> customers)
  {
    public GetAllCustomersResponse ToGetAllCustomersResponse() => 
      new GetAllCustomersResponse([.. customers.Select(customer => new GetAllCustomersResponseItem(
      customer.Id,
      customer.CompanyName,
      customer.OrganizationNumber,
      customer.ContactName,
      customer.Street,
      customer.PostalCode,
      customer.City,
      customer.Phone
    ))]);
  }
}
