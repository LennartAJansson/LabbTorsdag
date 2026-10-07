namespace Customers.Features.Customers.CreateCustomer;

using global::Customers.Features.Customers.Model;

public interface ICreateCustomerService
{
  Task<Customer> Create(Customer customer, CancellationToken cancellationToken = default);
}
