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
      .AddJsonFile("appsettings.json", optional: true)
      .AddUserSecrets<EmployeeContextFactory>(optional: true)
      .AddEnvironmentVariables()
      .Build();

    var optionsBuilder = new DbContextOptionsBuilder<EmployeeContext>();
    optionsBuilder.UseSqlServer(configuration.GetConnectionString("EmployeesConnection"));

    return new EmployeeContext(optionsBuilder.Options);
  }
}
