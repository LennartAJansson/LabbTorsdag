namespace Employees.Features.Employees.Mappers;

using System;
using System.Collections.Generic;
using System.Text;

using global::Employees.Features.Employees.Model;

using Messaging.Abstract;

using Microsoft.AspNetCore.Builder;

internal static class EmployeeToContractExtension
{
  extension(Employee employee)
  {
    public EmployeeContract ToContract()
    {
      return new EmployeeContract(
        employee.Id,
        employee.Title,
        employee.GivenName,
        employee.Surname,
        employee.Street,
        employee.PostalCode,
        employee.City,
        employee.Phone
      );
    }
  }
}
