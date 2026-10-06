namespace WebApplication1.Features.Customers.GetCustomers;

using WebApplication1.Core;
using WebApplication1.Features.Customers.Core;
using WebApplication1.Features.Customers.GetCustomer;

public sealed class GetAllCustomersHandler(IGetCustomersService customerReadService)
  : IRequestHandler<GetAllCustomersRequest, IEnumerable<GetCustomerResponse>>
{
  public async Task<Result<IEnumerable<GetCustomerResponse>>> HandleAsync(GetAllCustomersRequest request)
  {
    var customers = await customerReadService.Get();
    return Result.Success(customers.Select(c => c.ToGetCustomerResponse()));
  }
}
