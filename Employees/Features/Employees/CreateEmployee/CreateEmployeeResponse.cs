namespace Employees.Features.Employees.CreateEmployee;

public sealed class CreateEmployeeResponse(
  Guid id,
  string ssid,
  string title,
  string givenName,
  string surname,
  string street,
  string postalCode,
  string city,
  string phone)
{
  public Guid Id { get; } = id;
  public string SSID { get; } = ssid;
  public string Title { get; } = title;
  public string GivenName { get; } = givenName;
  public string Surname { get; } = surname;
  public string Street { get; } = street;
  public string PostalCode { get; } = postalCode;
  public string City { get; } = city;
  public string Phone { get; } = phone;
}
