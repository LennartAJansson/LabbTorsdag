namespace Employees.Features.Employees.DeleteEmployee;

using global::Employees.Features.Employees.Model;

public interface IDeleteEmployeeService
{
  Task<Employee?> DeleteEmployeeAsync(Guid id, CancellationToken cancellationToken);
}
