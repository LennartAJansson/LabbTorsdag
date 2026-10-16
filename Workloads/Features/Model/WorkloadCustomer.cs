namespace Workloads.Features.Model;

using System;
using System.Collections.Generic;

public class WorkloadCustomer
{
  public Guid Id { get; set; }
  public required string CompanyName { get; set; }

  public ICollection<Workload> Workloads { get; set; } = new HashSet<Workload>();
}

public class WorkloadEmployee
{
  public Guid Id { get; set; }
  public required string GivenName { get; set; }
  public required string Surname { get; set; }

  public ICollection<Workload> Workloads { get; set; } = new HashSet<Workload>();
}

public class Workload
{
  public Guid Id { get; set; }
  public required Guid EmployeeId { get; set; }
  public required Guid CustomerId { get; set; }
  public required DateTimeOffset Start { get; set; }
  public DateTimeOffset Stop { get; set; }
  public required string Notes { get; set; }

  public WorkloadCustomer? Customer { get; set; }
  public WorkloadEmployee? Employee { get; set; }
}