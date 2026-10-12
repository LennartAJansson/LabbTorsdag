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
      Name = r.Name
    };
  }

  public override CreateEmployeeResponse FromEntity(Employee e)
  {
    return new CreateEmployeeResponse(e.Id, e.Name);
  }
}
