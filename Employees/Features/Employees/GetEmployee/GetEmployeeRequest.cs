namespace Employees.Features.Employees.GetEmployee;

using Common;

using FastEndpoints;

public sealed class GetEmployeeRequest
  : ICommand<Result<GetEmployeeResponse>>
{
  public Guid Id { get; set; }
}
