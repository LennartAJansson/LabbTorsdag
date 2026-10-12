using FastEndpoints;

using Scalar.AspNetCore;

using WebApplication2.Features.Employees.CreateEmployee;
using WebApplication2.Infrastructure.Data.Extensions;
using WebApplication2.Infrastructure.Data.Services;

var bld = WebApplication.CreateBuilder();

bld.Services.AddOpenApi();
bld.Services.AddFastEndpoints();
bld.Services.AddEmployeesData(bld.Configuration);

var app = bld.Build();

app.MapOpenApi();
app.MapScalarApiReference();

app.UseApplicationData();

app.UseFastEndpoints();
app.Run();
