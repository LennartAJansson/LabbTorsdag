namespace Workloads.Features.Workloads.GetByEmployee;

public sealed record GetWorkloadsByEmployeeResponse(IReadOnlyList<WorkloadResponse> Workloads);
