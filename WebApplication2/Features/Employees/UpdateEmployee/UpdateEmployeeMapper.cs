namespace UpdateEmployee;

using FastEndpoints;

using WebApplication2.Features.Employees.Model;

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
