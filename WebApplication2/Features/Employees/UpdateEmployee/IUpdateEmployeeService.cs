namespace UpdateEmployee;

using WebApplication2.Features.Employees.Model;

public interface IUpdateEmployeeService
{
  Task<Employee?> UpdateEmployeeAsync(Employee employee, CancellationToken cancellationToken);
}
