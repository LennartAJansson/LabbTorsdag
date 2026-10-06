namespace WebApplication1.Features.Customers.GetCustomers;

using WebApplication1.Core;
using WebApplication1.Features.Customers.Core;

public sealed class GetCustomersHandler(IGetCustomersService customerReadService)
  : IRequestHandler<GetCustomersRequest, GetCustomersResponse>
{
  public async Task<Result<GetCustomersResponse>> HandleAsync(GetCustomersRequest request)
  {
    var customers = await customerReadService.Get();
    return Result.Success(customers.ToGetAllCustomersResponse());
  }
}
