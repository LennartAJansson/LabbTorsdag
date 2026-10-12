namespace Employees.Infrastructure.Data.Context;

using global::Employees.Features.Employees.Model;

using Microsoft.EntityFrameworkCore;

public class EmployeeContext(DbContextOptions<EmployeeContext> options)
  : DbContext(options)
{
  public DbSet<Employee> Employees => Set<Employee>();

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.ApplyConfigurationsFromAssembly(typeof(EmployeeContext).Assembly);

    base.OnModelCreating(modelBuilder);
  }
}
