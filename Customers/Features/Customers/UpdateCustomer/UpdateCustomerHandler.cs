namespace Customers.Features.Customers.UpdateCustomer;

using Common;

using Customers.Core;

using global::Customers.Features.Customers.Model;

using Messaging.Abstract;

public sealed class UpdateCustomerHandler(IUpdateCustomerService customerUpdateService, IMessaging<Customer> messaging)
  : IRequestHandler<UpdateCustomerRequest, UpdateCustomerResponse>
{
  public async Task<Result<UpdateCustomerResponse>> HandleAsync(UpdateCustomerRequest request)
  {
    var customer = await customerUpdateService.Update(request.ToCustomer());
    if (customer is null)
    {
      return Result.Failure<UpdateCustomerResponse>($"Customer with id {request.Id} not found.");
    }

    await messaging.PublishAsync(new Message<Customer>(MessageType.Update, customer), CancellationToken.None);
    return Result.Success(customer.ToUpdateCustomerResponse());
  }
}
