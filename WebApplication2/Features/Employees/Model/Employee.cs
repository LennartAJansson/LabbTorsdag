namespace WebApplication2.Features.Employees.Model;

public sealed class Employee
{
  public Guid Id { get; set; } = Guid.CreateVersion7();
  public required string Name { get; set; }
}
