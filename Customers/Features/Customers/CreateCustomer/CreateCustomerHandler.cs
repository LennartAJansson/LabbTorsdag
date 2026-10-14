namespace Customers.Features.Customers.CreateCustomer;

using Common;

using Customers.Core;

using FluentValidation;
using FluentValidation.Results;

using global::Customers.Features.Customers.Model;

using Messaging.Abstract;

public sealed class CreateCustomerHandler(ICreateCustomerService customerCreateService, IValidator<CreateCustomerRequest> validator, IMessaging<Customer> messaging)
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
    await messaging.PublishAsync(new Message<Customer>(MessageType.Create, customer), CancellationToken.None);
    return Result.Success(customer.ToCreateCustomerResponse());
  }
}
