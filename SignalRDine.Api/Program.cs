using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using SignalRDine.Api.Hubs;
using SignalRDine.Api.Middleware;
using SignalRDine.BusinessLayer.Abstract;
using SignalRDine.BusinessLayer.Concrete;
using SignalRDine.BusinessLayer.Container;
using SignalRDine.BusinessLayer.ValidationRules.BookingValidations;
using SignalRDine.DataAccessLayer.Abstract;
using SignalRDine.DataAccessLayer.Concrete;
using SignalRDine.DataAccessLayer.EntityFramework;
using System.Reflection;


var builder = WebApplication.CreateBuilder(args);

//  Serilog Configuration
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information() // Info, Warning, Error hepsi gelir
    .WriteTo.Console()
    .WriteTo.File(
        "Logs/log-.txt",
        rollingInterval: RollingInterval.Day,
        outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level:u3}] {Message:lj}{NewLine}{Exception}"
    )
    .CreateLogger();

builder.Host.UseSerilog();

// CORS ve SignalR
builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", builder =>
    {
        builder.AllowAnyHeader()
        .AllowAnyMethod()
        .SetIsOriginAllowed((host) => true)
        .AllowCredentials();
    });
});

builder.Services.AddSignalR();

//  DbContext & AutoMapper
builder.Services.AddDbContext<SignalRDineContext>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

// Dependency Injection (Scoped Services)
builder.Services.ContainerDependencies();

//FluentValidation
builder.Services.AddValidatorsFromAssemblyContaining<CreateBookingValidation>();
builder.Services.AddFluentValidationAutoValidation(config =>
{
    config.DisableDataAnnotationsValidation = true;
});

//Controllers
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

var app = builder.Build();
app.UseSerilogRequestLogging();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");
app.UseHttpsRedirection();
app.UseAuthorization();

app.UseMiddleware<ExceptionMiddleware>();

app.MapControllers();
app.MapHub<SignalRHub>("/signalrhub");

app.Run();