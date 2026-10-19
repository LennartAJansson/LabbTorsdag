namespace Workloads.Features.Workloads.Start;

using Common;
using FastEndpoints;
using FluentValidation;

public sealed class StartWorkloadRequest : ICommand<Result<WorkloadResponse>>
{
  public Guid CustomerId { get; set; }
  public Guid EmployeeId { get; set; }
  public string Notes { get; set; } = string.Empty;

  public sealed class Validator : Validator<StartWorkloadRequest>
  {
    public Validator()
    {
      RuleFor(x => x.CustomerId).NotEmpty();
      RuleFor(x => x.EmployeeId).NotEmpty();
      RuleFor(x => x.Notes).NotNull();
    }
  }
}
