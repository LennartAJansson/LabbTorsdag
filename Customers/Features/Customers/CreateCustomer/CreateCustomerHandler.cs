namespace Customers.Features.Customers.CreateCustomer;

using Common;

using FluentValidation;
using FluentValidation.Results;

using global::Customers.Features.Customers.Core;

using Customers.Core;
using global::Customers.Features.Customers.Model;

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
