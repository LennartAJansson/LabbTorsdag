namespace WebApplication1.Infrastructure.Data.Service;

using Microsoft.EntityFrameworkCore;

using WebApplication1.Features.Customers.CreateCustomer;
using WebApplication1.Features.Customers.DeleteCustomer;
using WebApplication1.Features.Customers.GetCustomer;
using WebApplication1.Features.Customers.GetCustomers;
using WebApplication1.Features.Customers.Model;
using WebApplication1.Features.Customers.UpdateCustomer;
using WebApplication1.Infrastructure.Data.Context;

public class CustomerService(CustomerContext context)
  : ICreateCustomerService, IUpdateCustomerService, IDeleteCustomerService, IGetCustomerService, IGetCustomersService
{
  public async Task<Customer> Create(Customer customer, CancellationToken cancellationToken = default)
  {
    context.Customers.Add(customer);
    await context.SaveChangesAsync(cancellationToken);
    return customer;
  }

  public async Task<Customer?> Delete(Guid customerId, CancellationToken cancellationToken = default)
  {
    var customer = context.Customers.FirstOrDefault(c => c.Id == customerId);
    if (customer is null)
      return null;

    context.Remove(customer);
    await context.SaveChangesAsync(cancellationToken);
    return customer;
  }

  public Task<IEnumerable<Customer>> Get(CancellationToken cancellationToken = default)
  {
    return Task.FromResult(context.Customers.AsNoTracking().AsEnumerable());
  }

  public Task<Customer?> GetById(Guid customerId, CancellationToken cancellationToken = default)
  {
    return Task.FromResult(context.Customers.AsNoTracking().FirstOrDefault(c => c.Id == customerId));
  }

  public async Task<Customer> Update(Customer customer, CancellationToken cancellationToken = default)
  {
    context.Update(customer);
    await context.SaveChangesAsync(cancellationToken);
    return customer;
  }
}
