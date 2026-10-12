namespace GetAllEmployees;

using WebApplication2.Features.Employees.Model;

public interface IGetAllEmployeesService
{
  Task<IEnumerable<Employee>> GetAllEmployeesAsync(CancellationToken cancellationToken);
}
