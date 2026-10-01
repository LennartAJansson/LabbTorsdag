namespace WebApplication1.Domain.Extensions;

using WebApplication1.Contract;
using WebApplication1.Domain.Model;

public static class Mappers
{
  extension(CreateCustomerRequest request)
  {
    public Customer ToCustomer() => new Customer
    {
      CompanyName = request.CompanyName
    };  
  }

  extension(UpdateCustomerRequest request)
  {
    public Customer ToCustomer() => new Customer
    {
      Id = request.Id,
      CompanyName = request.CompanyName
    };
  }

  extension(Customer customer)
  {
    public CreateCustomerResponse ToCreateCustomerResponse() => new CreateCustomerResponse(
      customer.Id,
      customer.CompanyName
    );
    public UpdateCustomerResponse ToUpdateCustomerResponse() => new UpdateCustomerResponse(
      customer.Id,
      customer.CompanyName
    );
    public DeleteCustomerResponse ToDeleteCustomerResponse() => new DeleteCustomerResponse(
      customer.Id,
      customer.CompanyName
    );
    public GetCustomerResponse ToGetCustomerResponse() => new GetCustomerResponse(
      customer.Id,
      customer.CompanyName
    );
  }

  extension(IEnumerable<Customer> customers)
  {
    public IEnumerable<GetCustomerResponse> ToGetCustomersResponse() => customers.Select(customer => new GetCustomerResponse(
      customer.Id,
      customer.CompanyName
    ));
  }
}
