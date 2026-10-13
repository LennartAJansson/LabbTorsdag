namespace Employees.Features.Employees.GetEmployee;

using FastEndpoints;

using global::Employees.Features.Employees.Model;

internal sealed class GetEmployeeMapper
  : Mapper<GetEmployeeRequest, GetEmployeeResponse, Employee>
{
  public override GetEmployeeResponse FromEntity(Employee e)
  {
    return new GetEmployeeResponse(e.Id, e.SSID, e.Title, e.GivenName, e.Surname, e.Street, e.PostalCode, e.City, e.Phone);
  }
}
