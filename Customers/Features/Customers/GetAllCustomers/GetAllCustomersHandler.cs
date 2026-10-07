namespace Customers.Features.Customers.GetAllCustomers;

using Common;

using Customers.Core;

public sealed class GetAllCustomersHandler(IGetAllCustomersService customerReadService)
  : IRequestHandler<GetAllCustomersRequest, GetAllCustomersResponse>
{
  public async Task<Result<GetAllCustomersResponse>> HandleAsync(GetAllCustomersRequest request)
  {
    var customers = await customerReadService.GetAll();
    return Result.Success(customers.ToGetAllCustomersResponse());
  }
}
