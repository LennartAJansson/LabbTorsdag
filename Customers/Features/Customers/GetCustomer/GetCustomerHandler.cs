using Customers.Features.Customers.GetCustomer;

namespace Customers.Features.Customers.GetCustomer;

using Common;

using Customers.Core;

using global::Customers.Features.Customers.Model;

public sealed class GetCustomerHandler(IGetCustomerService customerReadService)
  : IRequestHandler<GetCustomerRequest, GetCustomerResponse>
{
  public async Task<Result<GetCustomerResponse>> HandleAsync(GetCustomerRequest request)
  {
    Customer? customer = await customerReadService.Get(request.Id);
    return customer is null
      ? Result.Failure<GetCustomerResponse>($"Customer with id '{request.Id}' was not found.")
      : Result.Success(customer.ToGetCustomerResponse());
  }
}