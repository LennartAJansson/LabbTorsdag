namespace WebApplication2.Infrastructure.Data.Context;

using Microsoft.EntityFrameworkCore;

using WebApplication2.Features.Employees.Model;

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
