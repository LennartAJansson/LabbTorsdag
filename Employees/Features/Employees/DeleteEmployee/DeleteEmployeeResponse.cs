namespace Employees.Features.Employees.DeleteEmployee;

public sealed class DeleteEmployeeResponse(Guid id, string name)
{
  public Guid Id { get; } = id;
  public string Name { get; } = name;
}
