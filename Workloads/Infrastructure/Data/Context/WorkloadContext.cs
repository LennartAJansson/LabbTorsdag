namespace Workloads.Infrastructure.Data.Context;

using Microsoft.EntityFrameworkCore;

using Workloads.Features.Model;

public class WorkloadContext(DbContextOptions<WorkloadContext> options) : DbContext(options)
{
  public DbSet<WorkloadCustomer> Customers => Set<WorkloadCustomer>();
  public DbSet<WorkloadEmployee> Employees => Set<WorkloadEmployee>();
  public DbSet<Workload> Workloads => Set<Workload>();

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<WorkloadCustomer>(builder =>
    {
      builder.ToTable("WorkloadCustomers");
      builder.HasKey(c => c.Id);
      builder.Property(c => c.Id).ValueGeneratedNever();
      builder.Property(c => c.CompanyName).IsRequired();
    });

    modelBuilder.Entity<WorkloadEmployee>(builder =>
    {
      builder.ToTable("WorkloadEmployees");
      builder.HasKey(e => e.Id);
      builder.Property(e => e.Id).ValueGeneratedNever();
      builder.Property(e => e.GivenName).IsRequired();
      builder.Property(e => e.Surname).IsRequired();
    });

    modelBuilder.Entity<Workload>(builder =>
    {
      builder.ToTable("Workloads");
      builder.HasKey(w => w.Id);
      builder.Property(w => w.Notes).IsRequired();
      builder.HasOne(w => w.Customer).WithMany(c => c.Workloads)
        .HasForeignKey(w => w.CustomerId).OnDelete(DeleteBehavior.Restrict);
      builder.HasOne(w => w.Employee).WithMany(e => e.Workloads)
        .HasForeignKey(w => w.EmployeeId).OnDelete(DeleteBehavior.Restrict);
      builder.HasIndex(w => new { w.CustomerId, w.Start });
      builder.HasIndex(w => new { w.EmployeeId, w.Start });
    });

    base.OnModelCreating(modelBuilder);
  }
}
