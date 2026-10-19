namespace Workloads.Infrastructure.Data.Context;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

public class WorkloadContextFactory : IDesignTimeDbContextFactory<WorkloadContext>
{
  public WorkloadContext CreateDbContext(string[] args)
  {
    var configuration = new ConfigurationBuilder()
      .SetBasePath(Directory.GetCurrentDirectory())
      .AddJsonFile("appsettings.json", optional: true)
      .AddUserSecrets<WorkloadContextFactory>(optional: true)
      .AddEnvironmentVariables()
      .Build();

    var connectionString = configuration.GetConnectionString("WorkloadsConnection")
      ?? throw new InvalidOperationException("Connection string 'WorkloadsConnection' is required.");
    var options = new DbContextOptionsBuilder<WorkloadContext>()
      .UseSqlServer(connectionString)
      .Options;

    return new WorkloadContext(options);
  }
}
