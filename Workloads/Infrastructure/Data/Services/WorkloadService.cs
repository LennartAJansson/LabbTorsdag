namespace Workloads.Infrastructure.Data.Services;

using Microsoft.EntityFrameworkCore;

using Workloads.Features.Customers.GetAll;
using Workloads.Features.Customers.HandleChanges;
using Workloads.Features.Employees.GetAll;
using Workloads.Features.Employees.HandleChanges;
using Workloads.Features.Model;
using Workloads.Features.Workloads.GetByCustomer;
using Workloads.Features.Workloads.GetByEmployee;
using Workloads.Features.Workloads.Start;
using Workloads.Features.Workloads.Stop;
using Workloads.Infrastructure.Data.Context;

internal class WorkloadService(WorkloadContext context)
  : ICustomerChangeService, IEmployeeChangeService, IGetAllWorkloadCustomersService,
    IGetAllWorkloadEmployeesService, IStartWorkloadService, IStopWorkloadService,
    IGetWorkloadsByCustomerService, IGetWorkloadsByEmployeeService
{
  public Task<WorkloadCustomer> CreateCustomer(WorkloadCustomer customer, CancellationToken cancellationToken = default)
    => SaveCustomerAsync(customer, false, cancellationToken);

  public Task<WorkloadCustomer> UpdateCustomer(WorkloadCustomer customer, CancellationToken cancellationToken = default)
    => SaveCustomerAsync(customer, false, cancellationToken);

  public Task<WorkloadCustomer> DeleteCustomer(WorkloadCustomer customer, CancellationToken cancellationToken = default)
    => SaveCustomerAsync(customer, true, cancellationToken);

  public Task<WorkloadEmployee> CreateEmployee(WorkloadEmployee employee, CancellationToken cancellationToken = default)
    => SaveEmployeeAsync(employee, false, cancellationToken);

  public Task<WorkloadEmployee> UpdateEmployee(WorkloadEmployee employee, CancellationToken cancellationToken = default)
    => SaveEmployeeAsync(employee, false, cancellationToken);

  public Task<WorkloadEmployee> DeleteEmployee(WorkloadEmployee employee, CancellationToken cancellationToken = default)
    => SaveEmployeeAsync(employee, true, cancellationToken);

  private async Task<WorkloadCustomer> SaveCustomerAsync(WorkloadCustomer customer, bool isDeleted, CancellationToken ct)
  {
    var existing = await context.Customers.SingleOrDefaultAsync(c => c.Id == customer.Id, ct);
    if (existing is null)
    {
      existing = customer;
      context.Customers.Add(existing);
    }

    existing.CompanyName = customer.CompanyName;
    existing.IsDeleted = isDeleted;
    await context.SaveChangesAsync(ct);
    return existing;
  }

  private async Task<WorkloadEmployee> SaveEmployeeAsync(WorkloadEmployee employee, bool isDeleted, CancellationToken ct)
  {
    var existing = await context.Employees.SingleOrDefaultAsync(e => e.Id == employee.Id, ct);
    if (existing is null)
    {
      existing = employee;
      context.Employees.Add(existing);
    }

    existing.GivenName = employee.GivenName;
    existing.Surname = employee.Surname;
    existing.IsDeleted = isDeleted;
    await context.SaveChangesAsync(ct);
    return existing;
  }

  public async Task<IEnumerable<WorkloadCustomer>> GetAllCustomersAsync(CancellationToken cancellationToken)
    => await context.Customers.AsNoTracking().Where(c => !c.IsDeleted)
      .OrderBy(c => c.CompanyName).ThenBy(c => c.Id).ToListAsync(cancellationToken);

  public async Task<IEnumerable<WorkloadEmployee>> GetAllEmployeesAsync(CancellationToken cancellationToken)
    => await context.Employees.AsNoTracking().Where(e => !e.IsDeleted)
      .OrderBy(e => e.Surname).ThenBy(e => e.GivenName).ThenBy(e => e.Id).ToListAsync(cancellationToken);

  public async Task<Workload?> StartWorkloadAsync(Workload workload, CancellationToken cancellationToken)
  {
    if (!await context.Customers.AnyAsync(c => c.Id == workload.CustomerId && !c.IsDeleted, cancellationToken)
      || !await context.Employees.AnyAsync(e => e.Id == workload.EmployeeId && !e.IsDeleted, cancellationToken))
      return null;

    context.Workloads.Add(workload);
    await context.SaveChangesAsync(cancellationToken);
    return workload;
  }

  public async Task<Workload?> StopWorkloadAsync(Guid id, CancellationToken cancellationToken)
  {
    var stop = DateTimeOffset.UtcNow;
    // The conditional update preserves the first stop time, including concurrent PUT requests.
    await context.Workloads.Where(w => w.Id == id && w.Stop == null)
      .ExecuteUpdateAsync(update => update.SetProperty(w => w.Stop, stop), cancellationToken);

    return await context.Workloads.AsNoTracking().SingleOrDefaultAsync(w => w.Id == id, cancellationToken);
  }

  public async Task<IEnumerable<Workload>> GetWorkloadsByCustomerAsync(Guid customerId, CancellationToken cancellationToken)
    => await context.Workloads.AsNoTracking().Where(w => w.CustomerId == customerId)
      .OrderByDescending(w => w.Start).ThenBy(w => w.Id).ToListAsync(cancellationToken);

  public async Task<IEnumerable<Workload>> GetWorkloadsByEmployeeAsync(Guid employeeId, CancellationToken cancellationToken)
    => await context.Workloads.AsNoTracking().Where(w => w.EmployeeId == employeeId)
      .OrderByDescending(w => w.Start).ThenBy(w => w.Id).ToListAsync(cancellationToken);
}
