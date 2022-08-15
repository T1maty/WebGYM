using Microsoft.EntityFrameworkCore;
using ProductWebGYM.Data;
using ProductWebGYM.Models;
using ProductWebGYM.Services;
using ProductWebGYM.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddScoped<IAbonementService, AbonementService>();
builder.Services.AddDbContext<DbContextClass>(options =>
 options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
