namespace Employees.Features.Employees.GetAllEmployees;

public sealed record GetAllEmployeesResponse(IReadOnlyList<GetAllEmployeesResponseItem> Employees);

public sealed record GetAllEmployeesResponseItem(
  Guid Id,
  string SSID,
  string Title,
  string GivenName,
  string Surname,
  string Street,
  string PostalCode,
  string City,
  string Phone
);
