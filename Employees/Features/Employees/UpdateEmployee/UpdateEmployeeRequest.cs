namespace Employees.Features.Employees.UpdateEmployee;

using Common;

using global::Employees.Features.Employees.Validation;

using FastEndpoints;

using FluentValidation;

public sealed class UpdateEmployeeRequest
  : ICommand<Result<UpdateEmployeeResponse>>
{
  public Guid Id { get; set; }
  public string SSID { get; set; } = string.Empty;
  public string Title { get; set; } = string.Empty;
  public string GivenName { get; set; } = string.Empty;
  public string Surname { get; set; } = string.Empty;
  public string Street { get; set; } = string.Empty;
  public string PostalCode { get; set; } = string.Empty;
  public string City { get; set; } = string.Empty;
  public string Phone { get; set; } = string.Empty;

  public sealed class Validator : Validator<UpdateEmployeeRequest>
  {
    public Validator()
    {
      RuleFor(x => x.SSID)
        .NotEmpty().WithMessage("SSID is required.")
        .Must(SwedishPersonalIdentityNumberValidator.IsValid).WithMessage("SSID must be a valid Swedish personal identity number.");
      RuleFor(x => x.Title).NotEmpty().WithMessage("Title is required.");
      RuleFor(x => x.GivenName).NotEmpty().WithMessage("Given name is required.");
      RuleFor(x => x.Surname).NotEmpty().WithMessage("Surname is required.");
      RuleFor(x => x.Street).NotEmpty().WithMessage("Street is required.");
      RuleFor(x => x.PostalCode).NotEmpty().WithMessage("Postal code is required.");
      RuleFor(x => x.City).NotEmpty().WithMessage("City is required.");
      RuleFor(x => x.Phone).NotEmpty().WithMessage("Phone is required.");
    }
  }
}
