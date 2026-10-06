namespace WebApplication1.Features.Customers.GetCustomer;

using WebApplication1.Features.Customers.DeleteCustomer;
using WebApplication1.Features.Customers.Model;

public interface IGetCustomerService
{
  Task<Customer?> GetById(Guid customerId, CancellationToken cancellationToken = default);
}
