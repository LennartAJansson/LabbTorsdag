namespace WebApplication1.Domain.Services;

using WebApplication1.Domain.Model;

public interface ICustomerCreateService
{
  Task<Customer> Create(Customer customer, CancellationToken cancellationToken = default);
}
public interface ICustomerUpdateService
{
  Task<Customer> Update(Customer customer, CancellationToken cancellationToken = default);
}
public interface ICustomerDeleteService
{
  Task<Customer?> Delete(Guid customerId, CancellationToken cancellationToken = default);
}

public interface ICustomerReadService
{
  Task<Customer?> GetById(Guid customerId, CancellationToken cancellationToken = default);
  Task<IEnumerable<Customer>> Get(CancellationToken cancellationToken = default);
}

