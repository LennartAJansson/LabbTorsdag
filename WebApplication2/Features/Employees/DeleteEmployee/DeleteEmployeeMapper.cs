namespace DeleteEmployee;

using FastEndpoints;

using WebApplication2.Features.Employees.Model;

internal sealed class DeleteEmployeeMapper
  : Mapper<DeleteEmployeeRequest, DeleteEmployeeResponse, Employee>
{
  public override DeleteEmployeeResponse FromEntity(Employee e)
  {
    return new DeleteEmployeeResponse(e.Id, e.Name);
  }
}
