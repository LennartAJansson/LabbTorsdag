namespace Customers.Features.Customers.UpdateCustomer;

public record UpdateCustomerRequest(
  Guid Id,
  string CompanyName
);
