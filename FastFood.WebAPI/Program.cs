using FastFood.Application.UseCases.PlaceOrder;
using FastFood.Application.UseCases.RegisterCustomer;
using FastFood.Application.UseCases.GetProducts;
using FastFood.Application.UseCases.ManageProduct;
using FastFood.Application.UseCases.UpdateOrderStatus;

using FastFood.Domain.Repositories;
using FastFood.Infrastructure.Data;
using FastFood.Infrastructure.Repositories;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// ⬅️ ⬅️ AJUSTE 1: Adiciona fallback de configuração para Docker
builder.Configuration
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true)
    .AddJsonFile("appsettings.Docker.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables(); // útil para docker-compose com vars

// ⬅️ AJUSTE 2: Log de conexão (ajuda muito em debug)
var connectionString = builder.Configuration.GetConnectionString("Default");
Console.WriteLine($"📦 Usando connection string: {connectionString}");

// Configurar DbContext com PostgreSQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));

// Repositórios (Ports)
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

// Casos de uso (Use Cases)
builder.Services.AddScoped<PlaceOrderHandler>();
builder.Services.AddScoped<RegisterCustomerHandler>();
builder.Services.AddScoped<GetProductsByCategoryHandler>();
builder.Services.AddScoped<ManageProductHandler>();
builder.Services.AddScoped<UpdateOrderStatusHandler>();

// Controllers e Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// ⬅️ AJUSTE 3: Swagger sempre ativo local ou Docker
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
