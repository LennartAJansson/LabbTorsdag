namespace WebApplication1.Features.Customers.GetCustomers;

using WebApplication1.Features.Customers.Model;

public interface IGetCustomersService
{
  Task<IEnumerable<Customer>> Get(CancellationToken cancellationToken = default);
}
