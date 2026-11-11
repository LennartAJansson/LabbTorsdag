namespace Employees.Features.Employees.DeleteEmployee;

using global::Employees.Features.Employees.Model;

internal interface IDeleteEmployeeService
{
  Task<Employee?> DeleteEmployeeAsync(Guid id, CancellationToken cancellationToken);
}
