namespace GetEmployee;

using FastEndpoints;

public sealed class GetEmployeeRequest
  : ICommand<GetEmployeeResponse>
{
  public Guid Id { get; set; }
}
