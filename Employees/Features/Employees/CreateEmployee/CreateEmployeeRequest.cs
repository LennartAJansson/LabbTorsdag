namespace Employees.Features.Employees.CreateEmployee;

using Common;

using FastEndpoints;

using FluentValidation;

public sealed class CreateEmployeeRequest
  : ICommand<Result<CreateEmployeeResponse>>
{
  public string Name { get; set; } = string.Empty;

  public sealed class Validator : Validator<CreateEmployeeRequest>
  {
    public Validator()
    {
      RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.");
    }
  }
}
