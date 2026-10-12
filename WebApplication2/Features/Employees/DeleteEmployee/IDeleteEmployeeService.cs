namespace DeleteEmployee;

using WebApplication2.Features.Employees.Model;

public interface IDeleteEmployeeService
{
  Task<Employee?> DeleteEmployeeAsync(Guid id, CancellationToken cancellationToken);
}
