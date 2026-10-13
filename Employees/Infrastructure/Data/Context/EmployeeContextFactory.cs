namespace Employees.Infrastructure.Data.Context;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

public class EmployeeContextFactory : IDesignTimeDbContextFactory<EmployeeContext>
{
  public EmployeeContext CreateDbContext(string[] args)
  {
    IConfigurationRoot configuration = new ConfigurationBuilder()
      .SetBasePath(Directory.GetCurrentDirectory())
      .AddUserSecrets<EmployeeContextFactory>(optional: true)
      .Build();

    var optionsBuilder = new DbContextOptionsBuilder<EmployeeContext>();
    optionsBuilder.UseSqlServer(configuration.GetConnectionString("EmployeesConnection"));

    return new EmployeeContext(optionsBuilder.Options);
  }
}
