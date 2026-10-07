namespace Customers.Features.Customers.GetAllCustomers;

using global::Customers.Features.Customers.Model;

public interface IGetAllCustomersService
{
  Task<IEnumerable<Customer>> GetAll(CancellationToken cancellationToken = default);
}
