namespace GetEmployee;

using WebApplication2.Features.Employees.Model;

public interface IGetEmployeeService
{
  Task<Employee?> GetEmployeeAsync(Guid id, CancellationToken cancellationToken);
}
