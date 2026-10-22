namespace Workloads.Features.Model;

using System.Collections.Generic;

using Common.Data.Models;

public class WorkloadEmployee
{
  public Guid Id { get; set; }
  public required string GivenName { get; set; }
  public required string Surname { get; set; }
  public bool SourceIsDeleted { get; set; }

  public ICollection<Workload> Workloads { get; set; } = new HashSet<Workload>();
}
