namespace Employees.Features.Employees.UpdateEmployee;

using global::Employees.Features.Employees.Model;

internal interface IUpdateEmployeeService
{
  Task<Employee?> UpdateEmployeeAsync(Employee employee, CancellationToken cancellationToken);
}
