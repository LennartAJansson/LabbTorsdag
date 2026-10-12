namespace Customers.Infrastructure.Data.Context;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

public class CustomerContextFactory : IDesignTimeDbContextFactory<CustomerContext>
{
  public CustomerContext CreateDbContext(string[] args)
  {
    IConfigurationRoot configuration = new ConfigurationBuilder()
      .SetBasePath(Directory.GetCurrentDirectory())
      .AddJsonFile("appsettings.json", optional: true)
      .AddUserSecrets<CustomerContextFactory>(optional: true)
      .AddEnvironmentVariables()
      .Build();

    var optionsBuilder = new DbContextOptionsBuilder<CustomerContext>();
    optionsBuilder.UseSqlServer(configuration.GetConnectionString("CustomersConnection"));

    return new CustomerContext(optionsBuilder.Options);
  }
}
