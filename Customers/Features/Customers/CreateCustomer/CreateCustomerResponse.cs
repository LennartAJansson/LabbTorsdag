namespace Customers.Features.Customers.CreateCustomer;

public record CreateCustomerResponse(
  Guid Id,
  string CompanyName,
  string OrganizationNumber,
  string ContactName,
  string Street,
  string PostalCode,
  string City,
  string Phone
);
