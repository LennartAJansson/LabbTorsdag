namespace UpdateEmployee;

public sealed class UpdateEmployeeResponse(Guid id, string name)
{
  public Guid Id { get; } = id;
  public string Name { get; } = name;
}
