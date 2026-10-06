namespace WebApplication1.Features.Customers.CreateCustomer;

using WebApplication1.Features.Customers.Model;

public interface ICreateCustomerService
{
  Task<Customer> Create(Customer customer, CancellationToken cancellationToken = default);
}
