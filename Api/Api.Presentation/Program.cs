using Api.Application;
using Api.Application.Interface.Repository;
using Api.Application.Interface.Service;
using Api.Infra;
using Api.Infra.Repository;
using Dapper.FluentMap;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddTransient<IProcedureService, ProcedureService>();
builder.Services.AddTransient<IProcedureRepository, ProcedureRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();