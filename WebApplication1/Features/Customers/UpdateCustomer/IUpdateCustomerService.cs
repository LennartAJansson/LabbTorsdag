namespace WebApplication1.Features.Customers.UpdateCustomer;

using WebApplication1.Features.Customers.Model;

public interface IUpdateCustomerService
{
  Task<Customer> Update(Customer customer, CancellationToken cancellationToken = default);
}
