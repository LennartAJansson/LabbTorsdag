namespace Employees.Features.Employees.GetEmployee;

using global::Employees.Features.Employees.Model;

internal interface IGetEmployeeService
{
  Task<Employee?> GetEmployeeAsync(Guid id, CancellationToken cancellationToken);
}
