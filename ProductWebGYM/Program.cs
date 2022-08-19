using Microsoft.EntityFrameworkCore;
using ProductWebGYM.Data;
using Serilog;
using WebGYM.Shared.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context,config)=>
{ 
    config.WriteTo.Console();
});


builder.Services.AddDbContext<DbContextClass>(options =>
 options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<DbContext, DbContextClass>();
builder.Services.AddScoped<IGenericService, GenericService>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration.GetConnectionString("Redis");
    options.InstanceName = " Redis_GYM";


});

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
