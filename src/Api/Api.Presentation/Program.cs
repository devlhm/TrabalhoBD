using Api.Application;
using Api.Application.Interface.Repository;
using Api.Application.Interface.Service;
using Api.Infra.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddTransient<IProcedureService, ProcedureService>();
builder.Services.AddTransient<IProcedureRepository, ProcedureRepository>();
builder.Services.AddTransient<IInvoiceService, InvoiceService>();
builder.Services.AddTransient<IInvoiceRepository, InvoiceRepository>();
builder.Services.AddTransient<IProfessionalService, ProfessionalService>();
builder.Services.AddTransient<IProfessionalRepository, ProfessionalRepository>();
builder.Services.AddTransient<IClientService, ClientService>();
builder.Services.AddTransient<IClientRepository, ClientRepository>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<ISupplierRepository, SupplierRepository>();
builder.Services.AddTransient<ISupplierService, SupplierService>();
builder.Services.AddTransient<IBillingService, BillingService>();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
        policy.AllowAnyOrigin() // Permite qualquer origem
              .AllowAnyHeader() // Permite qualquer cabeçalho
              .AllowAnyMethod() // Permite qualquer método HTTP (GET, POST, etc.)
    );
});

Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;

var app = builder.Build();

app.UseCors();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();