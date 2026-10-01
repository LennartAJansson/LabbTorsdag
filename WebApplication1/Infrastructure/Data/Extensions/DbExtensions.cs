namespace WebApplication1.Infrastructure.Data.Extensions;

using Microsoft.EntityFrameworkCore;

using WebApplication1.Domain.Services;
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

      services.AddSingleton<CustomerInterceptor>();
      services.AddScoped<ICustomerCreateService, CustomerService>();
      services.AddScoped<ICustomerDeleteService, CustomerService>();
      services.AddScoped<ICustomerReadService, CustomerService>();
      services.AddScoped<ICustomerUpdateService, CustomerService>();

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