namespace WebApplication1.Features.Customers.DeleteCustomer;

using WebApplication1.Features.Customers.Model;

public interface IDeleteCustomerService
{
  Task<Customer?> Delete(Guid customerId, CancellationToken cancellationToken = default);
}
