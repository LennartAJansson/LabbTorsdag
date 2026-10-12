namespace DeleteEmployee;

using FastEndpoints;

public sealed class DeleteEmployeeRequest
  : ICommand<DeleteEmployeeResponse>
{
  public Guid Id { get; set; }
}
