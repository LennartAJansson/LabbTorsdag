namespace Workloads.Features.Customers.GetAll;

using Common;
using FastEndpoints;

internal sealed class GetAllWorkloadCustomersHandler(GetAllWorkloadCustomersMapper mapper, IGetAllWorkloadCustomersService service)
  : ICommandHandler<GetAllWorkloadCustomersRequest, Result<GetAllWorkloadCustomersResponse>>
{
  public async Task<Result<GetAllWorkloadCustomersResponse>> ExecuteAsync(GetAllWorkloadCustomersRequest command, CancellationToken ct)
    => Result.Success(mapper.FromEntity(await service.GetAllCustomersAsync(ct)));
}
