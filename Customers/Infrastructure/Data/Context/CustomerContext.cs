namespace Customers.Infrastructure.Data.Context;

using Microsoft.EntityFrameworkCore;

using Customers.Features.Customers.Model;

public class CustomerContext(DbContextOptions<CustomerContext> options) 
  : DbContext(options)
{
  public DbSet<Customer> Customers => Set<Customer>();

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.ApplyConfigurationsFromAssembly(typeof(CustomerContext).Assembly); 

    base.OnModelCreating(modelBuilder);
  }
}
