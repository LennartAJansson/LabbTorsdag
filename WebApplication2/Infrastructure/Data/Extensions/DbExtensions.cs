namespace WebApplication2.Infrastructure.Data.Extensions;

using Microsoft.EntityFrameworkCore;

using DeleteEmployee;
using GetAllEmployees;
using GetEmployee;
using UpdateEmployee;

using WebApplication2.Features.Employees.CreateEmployee;
using WebApplication2.Infrastructure.Data.Context;
using WebApplication2.Infrastructure.Data.Services;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Builder;

public static class DbExtensions
{
  extension(IServiceCollection services)
  {
    public IServiceCollection AddEmployeesData(IConfiguration configuration)
    {
      services.AddDbContext<EmployeeContext>(options =>
      {
        options.UseSqlServer(configuration.GetConnectionString("EmployeesConnection"));
      });

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
    public WebApplication UseApplicationData()
    {
      using var scope = app.Services.CreateScope();
      var context = scope.ServiceProvider.GetRequiredService<EmployeeContext>();
      if (context.Database.GetPendingMigrations().Any())
        context.Database.Migrate();

      return app;
    }
  }
}
