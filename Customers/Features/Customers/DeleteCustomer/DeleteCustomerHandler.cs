using Customers.Features.Customers.DeleteCustomer;

namespace Customers.Features.Customers.DeleteCustomer;

using Common;

using Customers.Core;

public sealed class DeleteCustomerHandler(IDeleteCustomerService customerDeleteService)
  : IRequestHandler<DeleteCustomerRequest, DeleteCustomerResponse>
{
  public async Task<Result<DeleteCustomerResponse>> HandleAsync(DeleteCustomerRequest request)
  {
    var customer = await customerDeleteService.Delete(request.Id);
    return customer is null
      ? Result.Failure<DeleteCustomerResponse>($"Customer with id '{request.Id}' was not found.")
      : Result.Success(customer.ToDeleteCustomerResponse());
  }
}
