namespace Customers.Features.Customers.UpdateCustomer;

public record UpdateCustomerRequest(
  Guid Id,
  string CompanyName,
  string OrganizationNumber,
  string ContactName,
  string Street,
  string PostalCode,
  string City,
  string Phone
);
