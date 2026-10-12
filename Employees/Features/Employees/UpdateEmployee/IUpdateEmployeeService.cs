namespace Employees.Features.Employees.UpdateEmployee;

using global::Employees.Features.Employees.Model;

public interface IUpdateEmployeeService
{
  Task<Employee?> UpdateEmployeeAsync(Employee employee, CancellationToken cancellationToken);
}
