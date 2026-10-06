namespace WebApplication1.Features.Customers.CreateCustomer;

using FluentValidation;
using FluentValidation.Results;

using WebApplication1.Core;
using WebApplication1.Features.Customers.Core;
using WebApplication1.Features.Customers.Model;

public sealed class CreateCustomerHandler(ICreateCustomerService customerCreateService, IValidator<CreateCustomerRequest> validator)
  : IRequestHandler<CreateCustomerRequest, CreateCustomerResponse>
{
  public async Task<Result<CreateCustomerResponse>> HandleAsync(CreateCustomerRequest request)
  {
    ValidationResult validationResult = await validator.ValidateAsync(request);
    if (!validationResult.IsValid)
    {
      return Result.Failure<CreateCustomerResponse>(string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage)));
    }

    Customer customer = await customerCreateService.Create(request.ToCustomer());
    return Result.Success(customer.ToCreateCustomerResponse());
  }
}
