namespace Employees.Features.Employees.CreateEmployee;

public sealed class CreateEmployeeResponse(Guid id, string name)
{
  public Guid Id { get; } = id;
  public string Name { get; } = name;
}
