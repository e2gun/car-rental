using CarRental.Api.Extensions;
using CarRental.Application;
using CarRental.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    
    app.ApplyMigrations();
    
    app.SeedData();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();