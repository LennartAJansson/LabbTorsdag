namespace Employees.Features.Employees.UpdateEmployee;

using FastEndpoints;

using global::Employees.Features.Employees.Model;

internal sealed class UpdateEmployeeMapper
  : Mapper<UpdateEmployeeRequest, UpdateEmployeeResponse, Employee>
{
  public override Employee ToEntity(UpdateEmployeeRequest r)
  {
    return new Employee
    {
      Id = r.Id,
      SSID = r.SSID,
      Title = r.Title,
      GivenName = r.GivenName,
      Surname = r.Surname,
      Street = r.Street,
      PostalCode = r.PostalCode,
      City = r.City,
      Phone = r.Phone
    };
  }

  public override UpdateEmployeeResponse FromEntity(Employee e)
  {
    return new UpdateEmployeeResponse(e.Id, e.SSID, e.Title, e.GivenName, e.Surname, e.Street, e.PostalCode, e.City, e.Phone);
  }
}
