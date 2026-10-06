namespace WebApplication1.Features.Customers.UpdateCustomer;

using WebApplication1.Core;
using WebApplication1.Features.Customers.Core;

public sealed class UpdateCustomerHandler(IUpdateCustomerService customerUpdateService)
  : IRequestHandler<UpdateCustomerRequest, UpdateCustomerResponse>
{
  public async Task<Result<UpdateCustomerResponse>> HandleAsync(UpdateCustomerRequest request)
  {
    var customer = await customerUpdateService.Update(request.ToCustomer());
    return Result.Success(customer.ToUpdateCustomerResponse());
  }
}
