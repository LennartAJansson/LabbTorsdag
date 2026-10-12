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
      Name = r.Name
    };
  }

  public override UpdateEmployeeResponse FromEntity(Employee e)
  {
    return new UpdateEmployeeResponse(e.Id, e.Name);
  }
}
