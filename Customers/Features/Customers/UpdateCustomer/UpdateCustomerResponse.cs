namespace Customers.Features.Customers.UpdateCustomer;

public record UpdateCustomerResponse(
  Guid Id,
  string CompanyName,
  string OrganizationNumber,
  string ContactName,
  string Street,
  string PostalCode,
  string City,
  string Phone
);
