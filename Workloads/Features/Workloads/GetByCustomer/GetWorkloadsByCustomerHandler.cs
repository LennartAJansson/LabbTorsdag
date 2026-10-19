namespace Workloads.Features.Workloads.GetByCustomer;

using Common;
using FastEndpoints;

internal sealed class GetWorkloadsByCustomerHandler(GetWorkloadsByCustomerMapper mapper, IGetWorkloadsByCustomerService service)
  : ICommandHandler<GetWorkloadsByCustomerRequest, Result<GetWorkloadsByCustomerResponse>>
{
  public async Task<Result<GetWorkloadsByCustomerResponse>> ExecuteAsync(GetWorkloadsByCustomerRequest command, CancellationToken ct)
    => Result.Success(mapper.FromEntity(await service.GetWorkloadsByCustomerAsync(command.CustomerId, ct)));
}
