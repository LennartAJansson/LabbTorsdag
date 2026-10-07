namespace Customers.Features.Customers.UpdateCustomer;

using global::Customers.Features.Customers.Model;

public interface IUpdateCustomerService
{
  Task<Customer> Update(Customer customer, CancellationToken cancellationToken = default);
}
