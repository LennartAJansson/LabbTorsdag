namespace WebApplication1.Infrastructure.Data.Context;

using Microsoft.EntityFrameworkCore;

using WebApplication1.Features.Customers.Model;

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
