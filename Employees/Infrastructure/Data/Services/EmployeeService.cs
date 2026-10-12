namespace Employees.Infrastructure.Data.Services;

using global::Employees.Features.Employees.CreateEmployee;
using global::Employees.Features.Employees.DeleteEmployee;
using global::Employees.Features.Employees.GetAllEmployees;
using global::Employees.Features.Employees.GetEmployee;
using global::Employees.Features.Employees.Model;
using global::Employees.Features.Employees.UpdateEmployee;
using global::Employees.Infrastructure.Data.Context;

using Microsoft.EntityFrameworkCore;

public class EmployeeService(EmployeeContext context)
  : ICreateEmployeeService, IGetEmployeeService, IGetAllEmployeesService, IUpdateEmployeeService, IDeleteEmployeeService
{
  public async Task<Employee> CreateEmployeeAsync(Employee employee, CancellationToken cancellationToken)
  {
    context.Employees.Add(employee);
    await context.SaveChangesAsync(cancellationToken);
    return employee;
  }

  public Task<Employee?> GetEmployeeAsync(Guid id, CancellationToken cancellationToken)
  {
    return Task.FromResult(context.Employees.AsNoTracking().FirstOrDefault(e => e.Id == id));
  }

  public Task<IEnumerable<Employee>> GetAllEmployeesAsync(CancellationToken cancellationToken)
  {
    return Task.FromResult(context.Employees.AsNoTracking().AsEnumerable());
  }

  public async Task<Employee?> UpdateEmployeeAsync(Employee employee, CancellationToken cancellationToken)
  {
    var existing = context.Employees.FirstOrDefault(e => e.Id == employee.Id);
    if (existing is null)
      return null;

    existing.Name = employee.Name;
    await context.SaveChangesAsync(cancellationToken);
    return existing;
  }

  public async Task<Employee?> DeleteEmployeeAsync(Guid id, CancellationToken cancellationToken)
  {
    var employee = context.Employees.FirstOrDefault(e => e.Id == id);
    if (employee is null)
      return null;

    context.Remove(employee);
    await context.SaveChangesAsync(cancellationToken);
    return employee;
  }
}
