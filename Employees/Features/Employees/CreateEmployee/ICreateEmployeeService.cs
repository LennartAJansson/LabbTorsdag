namespace Employees.Features.Employees.CreateEmployee;

using global::Employees.Features.Employees.Model;

internal interface ICreateEmployeeService
{
  Task<Employee> CreateEmployeeAsync(Employee employee, CancellationToken cancellationToken);
}
