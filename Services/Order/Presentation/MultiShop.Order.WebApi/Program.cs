using Microsoft.Extensions.DependencyInjection.Extensions;
using MultiShop.Order.Application.Features.CQRS.Handlers.AdressHandlers;
using MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Application.Services;
using MultiShop.Order.Persistence.Context;
using MultiShop.Order.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

builder.Services.AddApplicationService(builder.Configuration);

builder.Services.AddDbContext<OrderContext>();
//builder.Services.AddDbContext<OrderContext>();
// Add services to the container.

builder.Services.AddScoped<GetAdressByIdQueryHandler>();
builder.Services.AddScoped<GetAdressQueryHandler>();
builder.Services.AddScoped<CreateAdressCommandHandler>();
builder.Services.AddScoped<UpdateAdressCommandHandler>();
builder.Services.AddScoped<RemoveAdressCommandHandler>();

builder.Services.AddScoped<GetOrderDetailByIdQueryHandler>();
builder.Services.AddScoped<GetOrderDetailQueryHandler>();
builder.Services.AddScoped<CreateOrderDetailCommandHandler>();
builder.Services.AddScoped<UpdateOrderDetailCommandHandler>();
builder.Services.AddScoped<RemoveOrderDetailCommandHandler>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
