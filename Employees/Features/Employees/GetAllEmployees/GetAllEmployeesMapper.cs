namespace Employees.Features.Employees.GetAllEmployees;

using FastEndpoints;

using global::Employees.Features.Employees.Model;

internal sealed class GetAllEmployeesMapper
  : Mapper<GetAllEmployeesRequest, GetAllEmployeesResponse, IEnumerable<Employee>>
{
  public override GetAllEmployeesResponse FromEntity(IEnumerable<Employee> e)
  {
    return new GetAllEmployeesResponse(e.Select(employee => new GetAllEmployeesResponseItem(
      employee.Id,
      employee.Name
    )));
  }
}
