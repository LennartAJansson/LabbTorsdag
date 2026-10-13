namespace Employees.Features.Employees.CreateEmployee;

using FastEndpoints;

using global::Employees.Features.Employees.Model;

internal sealed class CreateEmployeeMapper
  : Mapper<CreateEmployeeRequest, CreateEmployeeResponse, Employee>
{
  public override Employee ToEntity(CreateEmployeeRequest r)
  {
    return new Employee
    {
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

  public override CreateEmployeeResponse FromEntity(Employee e)
  {
    return new CreateEmployeeResponse(e.Id, e.SSID, e.Title, e.GivenName, e.Surname, e.Street, e.PostalCode, e.City, e.Phone);
  }
}
