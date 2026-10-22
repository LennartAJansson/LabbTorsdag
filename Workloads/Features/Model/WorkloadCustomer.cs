namespace Workloads.Features.Model;

using System.Collections.Generic;

using Common.Data.Models;

public class WorkloadCustomer
{
  public Guid Id { get; set; }
  public required string CompanyName { get; set; }
  public bool SourceIsDeleted { get; set; }

  public ICollection<Workload> Workloads { get; set; } = new HashSet<Workload>();
}
