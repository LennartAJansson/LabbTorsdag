namespace GetAllEmployees;

using FastEndpoints;

using WebApplication2.Features.Employees.Model;

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
