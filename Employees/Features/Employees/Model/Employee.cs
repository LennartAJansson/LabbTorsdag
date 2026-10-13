namespace Employees.Features.Employees.Model;

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


public sealed class Employee : EntityBase
{
  public required string SSID { get; set; }
  public required string Title { get; set; }
  public required string GivenName { get; set; }
  public required string Surname { get; set; }
  public required string Street { get; set; }
  public required string PostalCode { get; set; }
  public required string City { get; set; }
  public required string Phone { get; set; }
}
