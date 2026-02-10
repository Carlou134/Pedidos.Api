using Pedidos.Api.Middlewares;
using Pedidos.Application.Interfaces;
using Pedidos.Application.Mappings;
using Pedidos.Application.Services;
using Pedidos.Domain.Interfaces;
using Pedidos.Infrastructure.Contexts;
using Pedidos.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSqlServer<PedidosContext>(
    builder.Configuration.GetConnectionString("dbPedidos")
);

builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<PedidoMappingProfile>();
});

builder.Services.AddScoped<IPedidoRepository, PedidoRepository>();
builder.Services.AddScoped<IPedidoService, PedidoService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy =>
        {
            policy
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin();
        });
});

var app = builder.Build();

app.UseMiddleware<GlobalExceptionHandler>();

app.UseCors("AllowFrontend");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
