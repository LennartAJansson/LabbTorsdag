namespace Customers.Features.Customers.Model;

using Common.Data.Models;

public sealed class Customer : EntityBase
{
  public required string CompanyName { get; set; }
  public required string OrganizationNumber { get; set; }
  public required string ContactName { get; set; }
  public required string Street { get; set; }
  public required string PostalCode { get; set; }
  public required string City { get; set; }
  public required string Phone { get; set; }
}
