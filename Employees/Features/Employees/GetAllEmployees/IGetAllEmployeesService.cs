namespace Employees.Features.Employees.GetAllEmployees;

using global::Employees.Features.Employees.Model;

internal interface IGetAllEmployeesService
{
  Task<IEnumerable<Employee>> GetAllEmployeesAsync(CancellationToken cancellationToken);
}
