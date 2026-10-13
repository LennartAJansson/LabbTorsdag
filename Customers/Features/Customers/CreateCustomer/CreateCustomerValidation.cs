namespace Customers.Features.Customers.CreateCustomer;

using FluentValidation;

public class CreateCustomerValidation
  : AbstractValidator<CreateCustomerRequest>
{
  public CreateCustomerValidation()
  {
    RuleFor(x => x.CompanyName).NotEmpty().WithMessage("Company name is required.");
    RuleFor(x => x.OrganizationNumber).NotEmpty().WithMessage("Organization number is required.");
    RuleFor(x => x.ContactName).NotEmpty().WithMessage("Contact name is required.");
    RuleFor(x => x.Street).NotEmpty().WithMessage("Street is required.");
    RuleFor(x => x.PostalCode).NotEmpty().WithMessage("Postal code is required.");
    RuleFor(x => x.City).NotEmpty().WithMessage("City is required.");
    RuleFor(x => x.Phone).NotEmpty().WithMessage("Phone is required.");
  }
}
