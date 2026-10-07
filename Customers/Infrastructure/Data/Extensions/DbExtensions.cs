namespace Customers.Infrastructure.Data.Extensions;

using Microsoft.EntityFrameworkCore;

using Customers.Features.Customers.CreateCustomer;
using Customers.Features.Customers.DeleteCustomer;
using Customers.Features.Customers.GetCustomer;
using Customers.Features.Customers.GetAllCustomers;
using Customers.Features.Customers.UpdateCustomer;
using Customers.Infrastructure.Data.Context;
using Customers.Infrastructure.Data.Interceptor;
using Customers.Infrastructure.Data.Service;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Builder;

public static class DbExtensions
{
  extension(IServiceCollection services)
  {
    public IServiceCollection AddCustomersData(IConfiguration configuration)
    {
      services.AddDbContext<CustomerContext>((sp, options) =>
      {
        options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        options.AddInterceptors(sp.GetRequiredService<CustomerInterceptor>());
      });

      services.AddHttpContextAccessor();
      services.AddSingleton<CustomerInterceptor>();
      services.AddScoped<ICreateCustomerService, CustomerService>();
      services.AddScoped<IDeleteCustomerService, CustomerService>();
      services.AddScoped<IGetCustomerService, CustomerService>();
      services.AddScoped<IGetAllCustomersService, CustomerService>();
      services.AddScoped<IUpdateCustomerService, CustomerService>();

      return services;
    }
  }

  extension(WebApplication app)
  {
    public WebApplication UseApplicationData()
    {
      using var scope = app.Services.CreateScope();
      var context = scope.ServiceProvider.GetRequiredService<CustomerContext>();
      if (context.Database.GetPendingMigrations().Any())
        context.Database.Migrate();

      return app;
    }
  }
}