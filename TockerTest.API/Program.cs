using TockerTest.API.persistence;
using TockerTest.API.Services;
using Microsoft.Extensions.DependencyInjection;
using TockerTest.API.Contract.Persitence;
using TockerTest.API.Models;
using TockerTest.API.persistence.Repository;
using Microsoft.EntityFrameworkCore;
using TockerTest.API.Contract.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplicationPersitenceServicesExtensions(builder.Configuration);
builder.Services.AddAplicationService();





builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder => builder.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("CorsPolicy");

app.MapControllers();

app.Run();
