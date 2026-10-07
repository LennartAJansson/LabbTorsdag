namespace Customers.Features.Customers.GetCustomer;

using Customers.Core;

public record GetCustomerResponse(
  Guid Id,
  string CompanyName
);
