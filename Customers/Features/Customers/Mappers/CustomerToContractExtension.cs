namespace Employees.Features.Employees.Mappers;

using System;
using System.Collections.Generic;
using System.Text;

using Customers.Features.Customers.Model;

using Messaging.Abstract;

using Microsoft.AspNetCore.Builder;

internal static class CustomerToContractExtension
{
  extension(Customer customer)
  {
    public CustomerContract ToContract()
    {
      return new CustomerContract(
        customer.Id,
        customer.CompanyName,
        customer.ContactName,
        customer.Street,
        customer.PostalCode,
        customer.City,
        customer.Phone
      );
    }
  }
}
