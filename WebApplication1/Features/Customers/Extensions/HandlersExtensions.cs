namespace WebApplication1.Features.Customers.Extensions;

using FluentValidation;

using WebApplication1.Features.Customers.Core;
using WebApplication1.Features.Customers.CreateCustomer;

public static class HandlersExtensions
{
  extension(IServiceCollection services)
  {
    public IServiceCollection AddHandlers()
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