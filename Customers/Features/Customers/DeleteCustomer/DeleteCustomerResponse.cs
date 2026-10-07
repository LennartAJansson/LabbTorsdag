namespace Customers.Features.Customers.DeleteCustomer;

public record DeleteCustomerResponse(
  Guid Id,
  string CompanyName
);
