namespace WebApplication2.Features.Employees.CreateEmployee;

using WebApplication2.Features.Employees.Model;

public interface ICreateEmployeeService
{
  Task<Employee> CreateEmployeeAsync(Employee employee, CancellationToken cancellationToken);
}
