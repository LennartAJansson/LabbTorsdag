namespace Customers.Features.Customers.DeleteCustomer;

public record DeleteCustomerResponse(
  Guid Id,
  string CompanyName,
  string OrganizationNumber,
  string ContactName,
  string Street,
  string PostalCode,
  string City,
  string Phone
);
