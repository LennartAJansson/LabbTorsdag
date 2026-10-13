namespace Customers.Features.Customers.GetAllCustomers;

public sealed record GetAllCustomersResponse(IReadOnlyList<GetAllCustomersResponseItem> Customers);

public record GetAllCustomersResponseItem(
  Guid Id,
  string CompanyName,
  string OrganizationNumber,
  string ContactName,
  string Street,
  string PostalCode,
  string City,
  string Phone
);
