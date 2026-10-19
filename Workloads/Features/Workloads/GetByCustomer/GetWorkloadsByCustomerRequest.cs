namespace Workloads.Features.Workloads.GetByCustomer;

using Common;
using FastEndpoints;
using FluentValidation;

public sealed class GetWorkloadsByCustomerRequest : ICommand<Result<GetWorkloadsByCustomerResponse>>
{
  public Guid CustomerId { get; set; }

  public sealed class Validator : Validator<GetWorkloadsByCustomerRequest>
  {
    public Validator()
    {
      RuleFor(x => x.CustomerId).NotEmpty();
    }
  }
}
