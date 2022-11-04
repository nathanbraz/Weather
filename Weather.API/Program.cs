using Microsoft.EntityFrameworkCore;
using Weather.API.AutoMapper;
using Weather.Infra.Context;
using Weather.Infra.Interfaces;
using Weather.Infra.Repositories;
using Weather.Services.Interfaces;
using Weather.Services.Services;

var builder = WebApplication.CreateBuilder(args);

string mySqlConnection = builder.Configuration.GetConnectionString("ConnectionMYSQL");

builder.Services.AddDbContext<WeatherContext>(options => options.UseMySql(mySqlConnection, ServerVersion.AutoDetect(mySqlConnection)));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IWeatherCityRepository, WeatherCityRepository>();
builder.Services.AddScoped<IWeatherCityService, WeatherCityService>();

builder.Services.AddAutoMapper(typeof(MappingConfiguration));

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
