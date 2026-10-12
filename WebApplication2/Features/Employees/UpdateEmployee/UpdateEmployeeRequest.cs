namespace UpdateEmployee;

using FastEndpoints;

using FluentValidation;

public sealed class UpdateEmployeeRequest
  : ICommand<UpdateEmployeeResponse>
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
