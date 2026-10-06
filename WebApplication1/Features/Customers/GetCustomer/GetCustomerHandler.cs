namespace WebApplication1.Features.Customers.GetCustomer;

using WebApplication1.Core;
using WebApplication1.Features.Customers.Core;
using WebApplication1.Features.Customers.Model;

public sealed class GetCustomerHandler(IGetCustomerService customerReadService)
  : IRequestHandler<GetCustomerRequest, GetCustomerResponse>
{
  public async Task<Result<GetCustomerResponse>> HandleAsync(GetCustomerRequest request)
  {
    Customer? customer = await customerReadService.GetById(request.Id);
    return customer is null
      ? Result.Failure<GetCustomerResponse>($"Customer with id '{request.Id}' was not found.")
      : Result.Success(customer.ToGetCustomerResponse());
  }
}