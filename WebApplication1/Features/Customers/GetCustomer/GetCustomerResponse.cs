namespace WebApplication1.Features.Customers.GetCustomer;

public record GetCustomerResponse(
  Guid Id,
  string CompanyName
);
