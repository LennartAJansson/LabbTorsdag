using Customers.Features.Customers.DeleteCustomer;

namespace Customers.Features.Customers.DeleteCustomer;

using Common;

using Customers.Core;

using Employees.Features.Employees.Mappers;

using global::Customers.Features.Customers.Model;

using Messaging.Abstract;

public sealed class DeleteCustomerHandler(IDeleteCustomerService customerDeleteService, IMessaging<CustomerContract> messaging)
  : IRequestHandler<DeleteCustomerRequest, DeleteCustomerResponse>
{
  public async Task<Result<DeleteCustomerResponse>> HandleAsync(DeleteCustomerRequest request)
  {
    var customer = await customerDeleteService.Delete(request.Id);
    if (customer is null)
      return Result.Failure<DeleteCustomerResponse>($"Customer with id '{request.Id}' was not found.");

    await messaging.PublishAsync(new Message<CustomerContract>(MessageType.Delete, customer.ToContract()), CancellationToken.None);

    return Result.Success(customer.ToDeleteCustomerResponse());
  }
}
