namespace WebApplication1.Features.Customers.GetCustomer;

using WebApplication1.Core;

public record GetCustomerResponse(
  Guid Id,
  string CompanyName
) : CustomerSummary(Id, CompanyName);
