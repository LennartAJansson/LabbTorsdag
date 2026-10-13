namespace Employees.Infrastructure.Data.Configuration;

using global::Employees.Features.Employees.Model;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class EmployeeConfiguration
  : IEntityTypeConfiguration<Employee>
{
  public void Configure(EntityTypeBuilder<Employee> builder)
  {
    builder.ToTable("Employees");
    builder.HasKey(e => e.Id);
    builder.Property(e => e.SSID).IsRequired();
    builder.Property(e => e.Title).IsRequired();
    builder.Property(e => e.GivenName).IsRequired();
    builder.Property(e => e.Surname).IsRequired();
    builder.Property(e => e.Street).IsRequired();
    builder.Property(e => e.PostalCode).IsRequired();
    builder.Property(e => e.City).IsRequired();
    builder.Property(e => e.Phone).IsRequired();
  }
}
