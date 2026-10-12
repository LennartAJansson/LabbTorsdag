namespace Employees.Features.Employees.UpdateEmployee;

using Common;

using FastEndpoints;

using FluentValidation;

public sealed class UpdateEmployeeRequest
  : ICommand<Result<UpdateEmployeeResponse>>
{
  public Guid Id { get; set; }
  public string Name { get; set; } = string.Empty;

  public sealed class Validator : Validator<UpdateEmployeeRequest>
  {
    public Validator()
    {
      RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.");
    }
  }
}
