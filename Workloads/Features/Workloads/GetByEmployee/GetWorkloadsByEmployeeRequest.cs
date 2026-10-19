namespace Workloads.Features.Workloads.GetByEmployee;

using Common;
using FastEndpoints;
using FluentValidation;

public sealed class GetWorkloadsByEmployeeRequest : ICommand<Result<GetWorkloadsByEmployeeResponse>>
{
  public Guid EmployeeId { get; set; }

  public sealed class Validator : Validator<GetWorkloadsByEmployeeRequest>
  {
    public Validator()
    {
      RuleFor(x => x.EmployeeId).NotEmpty();
    }
  }
}
