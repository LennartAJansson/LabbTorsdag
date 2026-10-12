namespace Employees.Features.Employees.DeleteEmployee;

using FastEndpoints;

using global::Employees.Features.Employees.Model;

internal sealed class DeleteEmployeeMapper
  : Mapper<DeleteEmployeeRequest, DeleteEmployeeResponse, Employee>
{
  public override DeleteEmployeeResponse FromEntity(Employee e)
  {
    return new DeleteEmployeeResponse(e.Id, e.Name);
  }
}
