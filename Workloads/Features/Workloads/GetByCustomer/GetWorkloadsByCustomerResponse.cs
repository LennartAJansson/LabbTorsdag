namespace Workloads.Features.Workloads.GetByCustomer;

public sealed record GetWorkloadsByCustomerResponse(IReadOnlyList<WorkloadResponse> Workloads);
