namespace GetEmployee;

using FastEndpoints;

using WebApplication2.Features.Employees.Model;

internal sealed class GetEmployeeMapper
  : Mapper<GetEmployeeRequest, GetEmployeeResponse, Employee>
{
  public override GetEmployeeResponse FromEntity(Employee e)
  {
    return new GetEmployeeResponse(e.Id, e.Name);
  }
}
