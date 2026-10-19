namespace Workloads.Features.Customers.GetAll;

using Common;
using FastEndpoints;

public sealed class GetAllWorkloadCustomersRequest : ICommand<Result<GetAllWorkloadCustomersResponse>>;
