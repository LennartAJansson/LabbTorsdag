namespace Workloads.Features.Workloads;

using global::Workloads.Features.Model;

public sealed record WorkloadResponse(
  Guid Id,
  Guid CustomerId,
  Guid EmployeeId,
  DateTimeOffset Start,
  DateTimeOffset? Stop,
  string Notes)
{
  internal static WorkloadResponse FromEntity(Workload workload)
  {
    return new(workload.Id, workload.CustomerId, workload.EmployeeId,
      workload.Start, workload.Stop, workload.Notes);
  }
}
