namespace Customers.Features.Customers.GetCustomer;

using Customers.Core;

public record GetCustomerResponse(
  Guid Id,
  string CompanyName,
  string OrganizationNumber,
  string ContactName,
  string Street,
  string PostalCode,
  string City,
  string Phone
);
