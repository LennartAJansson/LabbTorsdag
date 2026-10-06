namespace WebApplication1.Features.Customers.DeleteCustomer;

using WebApplication1.Core;
using WebApplication1.Features.Customers.Core;

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
