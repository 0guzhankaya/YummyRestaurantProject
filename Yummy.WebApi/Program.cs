using FluentValidation;
using System.Reflection;
using Yummy.WebApi.Context;
using Yummy.WebApi.Entities;
using Yummy.WebApi.Validation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ApiContext>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly()); // AutoMapper'ý servis olarak ekliyoruz ve mevcut assembly'i tarýyoruz.
builder.Services.AddScoped<IValidator<Product>, ProductValidator>(); // ProductValidator'ý IValidator<Product> olarak servis koleksiyonuna ekliyoruz.

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
