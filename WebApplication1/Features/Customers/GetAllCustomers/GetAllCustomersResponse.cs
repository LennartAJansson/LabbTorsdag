namespace WebApplication1.Features.Customers.GetCustomers;

using System.Collections;

using WebApplication1.Core;

public sealed class GetCustomersResponse(IEnumerable<GetCustomersResponseItem> customers) 
  : IEnumerable<GetCustomersResponseItem>
{
  private readonly IEnumerable<GetCustomersResponseItem> _customers = customers;

  public IEnumerator<GetCustomersResponseItem> GetEnumerator() => _customers.GetEnumerator();

  IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public record GetCustomersResponseItem(
  Guid Id,
  string CompanyName
) : CustomerSummary(Id, CompanyName);
