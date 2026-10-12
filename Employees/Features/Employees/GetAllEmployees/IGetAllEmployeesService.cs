namespace Employees.Features.Employees.GetAllEmployees;

using global::Employees.Features.Employees.Model;

public interface IGetAllEmployeesService
{
  Task<IEnumerable<Employee>> GetAllEmployeesAsync(CancellationToken cancellationToken);
}
