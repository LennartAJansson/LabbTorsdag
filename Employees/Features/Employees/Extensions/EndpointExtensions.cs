namespace Employees.Features.Employees.Extensions;

using FastEndpoints;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

public static class EndpointExtensions
{
  extension(WebApplication app)
  {
    // Denna används bara om man vill ha en egen UseFastEndpoints för Employees, 
    // Detta kan vara om man vill köra denna i en separat applikation (container exempelvis)
    public WebApplication MapEmployeesEndpoints()
    {
      app.UseFastEndpoints(options =>
      {
        options.Endpoints.Configurator = endpoint =>
          endpoint.Options(builder => builder.WithTags(endpoint.EndpointType.Assembly.GetName().Name!));
      });

      return app;
    }
  }
}
