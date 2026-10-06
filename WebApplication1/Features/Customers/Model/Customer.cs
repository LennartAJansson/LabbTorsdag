namespace WebApplication1.Features.Customers.Model;

public class EntityBase
{
  public Guid Id { get; set; } = Guid.CreateVersion7();
  public DateTimeOffset Created { get; set; } = DateTimeOffset.UtcNow;
  public Guid? CreatedBy { get; set; }
  public DateTimeOffset Changed { get; set; } = DateTimeOffset.UtcNow;
  public Guid? ChangedBy { get; set; }
  public DateTimeOffset Deleted { get; set; }
  public Guid? DeletedBy { get; set; }
  public bool IsDeleted { get; set; }

}


public sealed class Customer : EntityBase
{
  public required string CompanyName { get; set; }
}
