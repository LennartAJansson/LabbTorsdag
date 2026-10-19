namespace Workloads.Features.Workloads.Stop;

using Common;
using FastEndpoints;
using FluentValidation;

public sealed class StopWorkloadRequest : ICommand<Result<WorkloadResponse>>
{
  public Guid Id { get; set; }

  public sealed class Validator : Validator<StopWorkloadRequest>
  {
    public Validator()
    {
      RuleFor(x => x.Id).NotEmpty();
    }
  }
}
