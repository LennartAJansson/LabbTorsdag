namespace WebApplication2.Infrastructure.Data.Configuration;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using WebApplication2.Features.Employees.Model;

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
