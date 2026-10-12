namespace Employees.Features.Employees.GetAllEmployees;

using Common;

using FastEndpoints;

public sealed class GetAllEmployeesRequest
  : ICommand<Result<GetAllEmployeesResponse>>
{
}
