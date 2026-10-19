namespace Workloads.Features.Employees.GetAll;

using Common;
using FastEndpoints;

public sealed class GetAllWorkloadEmployeesRequest : ICommand<Result<GetAllWorkloadEmployeesResponse>>;
