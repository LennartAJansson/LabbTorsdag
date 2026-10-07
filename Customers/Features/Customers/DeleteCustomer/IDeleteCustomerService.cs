namespace Customers.Features.Customers.DeleteCustomer;

using global::Customers.Features.Customers.Model;

public interface IDeleteCustomerService
{
  Task<Customer?> Delete(Guid customerId, CancellationToken cancellationToken = default);
}
