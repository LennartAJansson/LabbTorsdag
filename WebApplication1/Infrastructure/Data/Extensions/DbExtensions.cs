namespace WebApplication1.Infrastructure.Data.Extensions;

using Microsoft.EntityFrameworkCore;

using WebApplication1.Features.Customers.CreateCustomer;
using WebApplication1.Features.Customers.DeleteCustomer;
using WebApplication1.Features.Customers.GetCustomer;
using WebApplication1.Features.Customers.GetCustomers;
using WebApplication1.Features.Customers.UpdateCustomer;
using WebApplication1.Infrastructure.Data.Context;
using WebApplication1.Infrastructure.Data.Interceptor;
using WebApplication1.Infrastructure.Data.Service;

public static class DbExtensions
{
  extension(IServiceCollection services)
  {
    public IServiceCollection AddApplicationData(IConfiguration configuration)
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
      services.AddScoped<IGetCustomersService, CustomerService>();
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