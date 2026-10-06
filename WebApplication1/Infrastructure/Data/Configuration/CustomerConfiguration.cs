namespace WebApplication1.Infrastructure.Data.Configuration;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using WebApplication1.Features.Customers.Model;

public class CustomerConfiguration
  : IEntityTypeConfiguration<Customer>
{
  public void Configure(EntityTypeBuilder<Customer> builder)
  {
    builder.ToTable("Customers"); 
    builder.HasKey(e => e.Id);
    builder.Property(e => e.CompanyName).IsRequired();
    builder.Property(e => e.Created).IsRequired();
    builder.Property(e => e.Changed).IsRequired();
    builder.Property(e => e.IsDeleted).IsRequired();
    builder.HasQueryFilter(e => !e.IsDeleted);
  }
}
