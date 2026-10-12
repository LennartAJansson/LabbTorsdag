namespace WebApplication2.Features.Employees.CreateEmployee;

using FastEndpoints;

using FluentValidation;

public sealed class CreateEmployeeRequest
  : ICommand<CreateEmployeeResponse>
{
  public string Name { get; set; }

  public sealed class Validator : Validator<CreateEmployeeRequest>
  {
    public Validator()
    {
      RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.");
    }
  }
}
