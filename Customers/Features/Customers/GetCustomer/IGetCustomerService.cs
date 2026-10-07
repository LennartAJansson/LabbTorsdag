namespace Customers.Features.Customers.GetCustomer;

using global::Customers.Features.Customers.Model;

public interface IGetCustomerService
{
  Task<Customer?> Get(Guid customerId, CancellationToken cancellationToken = default);
}
