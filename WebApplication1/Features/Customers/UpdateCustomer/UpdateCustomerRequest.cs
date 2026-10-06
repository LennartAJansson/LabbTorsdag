namespace WebApplication1.Features.Customers.UpdateCustomer;

public record UpdateCustomerRequest(
  Guid Id,
  string CompanyName
);
