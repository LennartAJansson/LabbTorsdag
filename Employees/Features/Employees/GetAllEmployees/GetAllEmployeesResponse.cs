namespace Employees.Features.Employees.GetAllEmployees;

using System.Collections;

public sealed class GetAllEmployeesResponse(IEnumerable<GetAllEmployeesResponseItem> employees)
  : IEnumerable<GetAllEmployeesResponseItem>
{
  private readonly IEnumerable<GetAllEmployeesResponseItem> _employees = employees;

  public IEnumerator<GetAllEmployeesResponseItem> GetEnumerator() => _employees.GetEnumerator();

  IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public sealed record GetAllEmployeesResponseItem(
  Guid Id,
  string Name
);
