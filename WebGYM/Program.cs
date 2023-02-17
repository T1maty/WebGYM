using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WebGYM.Application.Common.Mappings;
using WebGYM.Application.Interfaces;
using MediatR;
using WebGYM.Persistance;

using WebGYM.Application;
using Microsoft.AspNetCore.Hosting;
using WebAPI.Service.Interfaces;
using WebAPI.Service;
using Serilog;
using Serilog.Events;


var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
    .WriteTo.File("WebAppUserLog.txt", rollingInterval:
    RollingInterval.Day)
    .CreateLogger();



builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration.GetConnectionString("Redis");
    options.InstanceName = "WebGym_";
});


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplication();
builder.Services.AddOptions();

//DI 
builder.Services.AddScoped<ISubscriptionSevice, SubscriptionService>();
builder.Services.AddSingleton<ICurrentUserService, CurrentUserService>(); 

builder.Services.AddHttpContextAccessor();

//Add XML file to swagger
builder.Services.AddSwaggerGen(config =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    config.IncludeXmlComments(xmlPath);
});

builder.Host.UseSerilog((context, config) =>
{
    config.WriteTo.Console();
});

//Settings Automapper
builder.Services.AddAutoMapper(config =>
{
    config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
    config.AddProfile(new AssemblyMappingProfile(typeof(IWebGymContext).Assembly));
});

 



//Settings CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
        policy.AllowAnyOrigin();
    });
});


builder.Services.AddDbContext<WebGymDbContext>(
    o => o.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//Middleware 
app.UseHttpsRedirection();

app.UseRouting();


app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
