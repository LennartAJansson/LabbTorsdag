namespace Customers.Infrastructure.Data.Configuration;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Customers.Features.Customers.Model;

public class CustomerConfiguration
  : IEntityTypeConfiguration<Customer>
{
  public void Configure(EntityTypeBuilder<Customer> builder)
  {
    builder.ToTable("Customers"); 
    builder.HasKey(e => e.Id);
    builder.Property(e => e.CompanyName).IsRequired();
    builder.Property(e => e.OrganizationNumber).IsRequired();
    builder.Property(e => e.ContactName).IsRequired();
    builder.Property(e => e.Street).IsRequired();
    builder.Property(e => e.PostalCode).IsRequired();
    builder.Property(e => e.City).IsRequired();
    builder.Property(e => e.Phone).IsRequired();
    builder.Property(e => e.Created).IsRequired();
    builder.Property(e => e.Changed).IsRequired();
    builder.Property(e => e.IsDeleted).IsRequired();
    builder.HasQueryFilter(e => !e.IsDeleted);
  }
}
