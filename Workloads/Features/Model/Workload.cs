namespace Workloads.Features.Model;

using System;

using Common.Data.Models;

public class Workload: EntityBase
{
  public required Guid EmployeeId { get; set; }
  public required Guid CustomerId { get; set; }
  public required DateTimeOffset Start { get; set; }
  public DateTimeOffset? Stop { get; set; }
  public required string Notes { get; set; }

  public WorkloadCustomer? Customer { get; set; }
  public WorkloadEmployee? Employee { get; set; }
}