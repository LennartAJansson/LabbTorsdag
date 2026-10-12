namespace Employees.Features.Employees.DeleteEmployee;

using Common;

using FastEndpoints;

public sealed class DeleteEmployeeRequest
  : ICommand<Result<DeleteEmployeeResponse>>
{
  public Guid Id { get; set; }
}
