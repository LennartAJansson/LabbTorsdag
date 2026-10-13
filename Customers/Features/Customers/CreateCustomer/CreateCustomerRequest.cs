namespace Customers.Features.Customers.CreateCustomer;

public record CreateCustomerRequest(
  string CompanyName,
  string OrganizationNumber,
  string ContactName,
  string Street,
  string PostalCode,
  string City,
  string Phone
);
