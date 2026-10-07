namespace Customers.Features.Customers.Extensions;

using FluentValidation;

using global::Customers.Features.Customers.Core;
using global::Customers.Features.Customers.CreateCustomer;

using Microsoft.Extensions.DependencyInjection;

public static class HandlersExtensions
{
  extension(IServiceCollection services)
  {
    public IServiceCollection AddCustomersHandlers()
    {
      services.AddValidatorsFromAssembly(typeof(CreateCustomerValidation).Assembly, ServiceLifetime.Scoped);
      var handlerTypes = typeof(IRequestHandler<,>).Assembly
        .GetTypes()
        .Where(type => type is { IsClass: true, IsAbstract: false });

      foreach (var handlerType in handlerTypes)
      {
        var handlerInterfaces = handlerType
          .GetInterfaces()
          .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IRequestHandler<,>));

        foreach (var handlerInterface in handlerInterfaces)
        {
          services.AddScoped(handlerInterface, handlerType);
        }
      }

      return services;
    }
  }
}