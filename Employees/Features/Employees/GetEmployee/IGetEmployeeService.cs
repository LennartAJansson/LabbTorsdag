namespace Employees.Features.Employees.GetEmployee;

using global::Employees.Features.Employees.Model;

public interface IGetEmployeeService
{
  Task<Employee?> GetEmployeeAsync(Guid id, CancellationToken cancellationToken);
}
