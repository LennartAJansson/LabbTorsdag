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
    builder.Property(e => e.Name).IsRequired();
  }
}
