namespace Customers.Features.Customers.GetAllCustomers;

using System.Collections;

using Customers.Core;

public sealed class GetAllCustomersResponse(IEnumerable<GetAllCustomersResponseItem> customers) 
  : IEnumerable<GetAllCustomersResponseItem>
{
  private readonly IEnumerable<GetAllCustomersResponseItem> _customers = customers;

  public IEnumerator<GetAllCustomersResponseItem> GetEnumerator() => _customers.GetEnumerator();

  IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public record GetAllCustomersResponseItem(
  Guid Id,
  string CompanyName
);
