namespace Employees.Infrastructure.Data.Extensions;

using Common.Data.Interceptor;

using global::Employees.Features.Employees.CreateEmployee;
using global::Employees.Features.Employees.DeleteEmployee;
using global::Employees.Features.Employees.GetAllEmployees;
using global::Employees.Features.Employees.GetEmployee;
using global::Employees.Features.Employees.UpdateEmployee;
using global::Employees.Infrastructure.Data.Context;
using global::Employees.Infrastructure.Data.Services;

using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class DbExtensions
{
  extension(IServiceCollection services)
  {
    public IServiceCollection AddEmployeesData(IConfiguration configuration)
    {
      services.AddDbContext<EmployeeContext>((sp, options) =>
      {
        options.UseSqlServer(configuration.GetConnectionString("EmployeesConnection"));
        options.AddInterceptors(sp.GetRequiredService<EntityBaseInterceptor>());
      });

      services.AddHttpContextAccessor();
      services.AddSingleton<EntityBaseInterceptor>();
      services.AddScoped<ICreateEmployeeService, EmployeeService>();
      services.AddScoped<IGetEmployeeService, EmployeeService>();
      services.AddScoped<IGetAllEmployeesService, EmployeeService>();
      services.AddScoped<IUpdateEmployeeService, EmployeeService>();
      services.AddScoped<IDeleteEmployeeService, EmployeeService>();

      return services;
    }
  }

  extension(WebApplication app)
  {
    public WebApplication UseEmployeesData()
    {
      using var scope = app.Services.CreateScope();
      var context = scope.ServiceProvider.GetRequiredService<EmployeeContext>();
      if (context.Database.GetPendingMigrations().Any())
        context.Database.Migrate();

      return app;
    }
  }
}
