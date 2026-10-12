namespace GetEmployee;

public sealed class GetEmployeeResponse(Guid id, string name)
{
  public Guid Id { get; } = id;
  public string Name { get; } = name;
}
