namespace WebApplication1.Features.Customers.CreateCustomer;

using FluentValidation;

public class CreateCustomerValidation
  : AbstractValidator<CreateCustomerRequest>
{
  public CreateCustomerValidation()
  {
    RuleFor(x => x.CompanyName).NotEmpty().WithMessage("Company name is required.");
  }
}
