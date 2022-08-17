using Microsoft.EntityFrameworkCore;
using ProductWebGYM.Data;
using WebGYM.Shared.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<DbContextClass>(options =>
 options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<DbContext, DbContextClass>();
builder.Services.AddScoped<IGenericService, GenericService>();

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
