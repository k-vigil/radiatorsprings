using RadiatorSprings.Api.Middlewares;
using RadiatorSprings.Application;
using RadiatorSprings.Infrastructure;
//using RadiatorSprings.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);

builder.Services.AddTransient<GlobalExceptionHandlerMiddleware>();

var app = builder.Build();

//app.Seed();

app.UseMiddleware<GlobalExceptionHandlerMiddleware>();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run();
